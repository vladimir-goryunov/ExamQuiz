using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UsabilityFactoryExamQuiz.Model.DataContract;
using UsabilityFactoryExamQuiz.Model.EF;
using UsabilityFactoryExamQuiz.Model.EF.Models;
using UsabilityFactoryExamQuiz.Utils.Exceptions;
using UsabilityFactoryExamQuiz.Utils.Helpers;
using UsabilityFactoryExamQuiz.Utils.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace UsabilityFactoryExamQuiz.Utils.Repositories
{
    /// <summary>
    /// Реализация основных методов работы с ответами на вопросы
    /// </summary>
    public class AnswerRepository : IAnswerRepository
    {
        private readonly IQuestionaireDBContext _dbContext;
        private readonly IFileRepository _attachmentRepository;
        private readonly ILogger _logger;

        public AnswerRepository(IQuestionaireDBContext context, 
                                IFileRepository attachmentRepository,
                                ILoggerFactory loggerFactory)
        {
            _dbContext = context;
            _attachmentRepository = attachmentRepository;
            _logger = loggerFactory?.CreateLogger(nameof(AnswerRepository)) ?? throw new ArgumentNullException(nameof(loggerFactory));            
        }

        /// <summary>
        /// Ищем в БД ответ по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private AnswerEntity GetAnswerById(Guid id)
        {
            return _dbContext.Answers.FirstOrDefault(u => u.Id.Equals(id));
        }

        /// <summary>
        /// Сохраняем файлы вложений в Azure Storage Blob, а инфо о файлах в БД MS SQL Express
        /// </summary>
        /// <param name="attachmentModel">Модель вложений к ответу на вопрос</param>
        public void SaveAnswerAttachments(AttachmentModel attachmentModel)
        {
            Guid answerId = attachmentModel != null ? attachmentModel.AnswerId : throw new AnswerNotFoundException();
            AnswerEntity answer = GetAnswerById(answerId);
            if (answer == null) throw new AnswerNotFoundException();

            var files = attachmentModel.Files.ToList();
            int savedAttachments = 0;
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var attachment = new AnswerAttachmentEntity(answerId)
                    {
                        Id = Guid.NewGuid(),
                        Created = DateTime.Now,
                        MimeType = MimeTypeHelper.GetMimeType(Path.GetExtension(file.FileName)),
                        FileName = file.FileName,
                        Size = file.Length > int.MaxValue ? int.MaxValue : (int)file.Length
                    };
                    try
                    {
                        var fileName = attachment.Id.ToString() + Path.GetExtension(file.FileName);
                        _attachmentRepository.SaveFile(fileName, file);
                        answer.Attachments.Add(attachment);
                        savedAttachments++;
                    }
                    catch (Exception ex)
                    {
                        var errorMessage = $"Невозможно сохранить вложение для attachmentId={attachment.Id}. Ошибка при сохранении файла в Azure Storage - {ex.Message}";
                        _logger.LogError(ex.InnerException ?? ex, errorMessage);
                    }
                }
            }

            if (files.Count != savedAttachments) throw new CoreException("Не удалось сохранить вложения. Подробности см. в лог файле.");
            _dbContext.SaveChanges(); // Обновляем answer после добавления аттачей
        }

        /// <summary>
        /// Сохраняем события в БД MS SQL Express 
        /// </summary>
        /// <param name="eventModel">Модель событий, описывающие поведение пользователя при ответе на вопрос</param>
        public void SaveAnswerEvents(EventModel eventModel)
        {
            Guid answerId = eventModel != null ? eventModel.AnswerId : throw new AnswerNotFoundException();
            var answer = GetAnswerById(answerId);
            if (answer == null) throw new AnswerNotFoundException();

            answer.Events = eventModel.Events;

            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Получим все ответы
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<AnswerEntity>> GetAll()
        {
            return await _dbContext.Answers.ToListAsync();
        }

        
    }
}
