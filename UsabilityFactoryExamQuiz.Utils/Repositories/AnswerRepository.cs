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

        public void SaveAnswerAttachments(AttachmentModel attachmentModel)
        {
            Guid answerId = attachmentModel != null ? attachmentModel.AnswerId : throw new AnswerNotFoundException();
            AnswerEntity answer = GetAnswerById(answerId);
            if (answer == null) throw new AnswerNotFoundException();

            var files = attachmentModel.Files.ToList();
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
                    }
                    catch (Exception ex)
                    {
                        var errorMessage = $"Невозможно сохранить вложение для attachmentId={attachment.Id}. Ошибка при сохранении файла в Azure Storage - {ex.Message}";
                        _logger.LogError(ex.InnerException ?? ex, errorMessage);
                    }
                }
            }
            _dbContext.SaveChanges(); // Обновляем answer после добавления аттачей

        }

        public void SaveAnswerEvents(EventModel eventModel)
        {
            Guid answerId = eventModel != null ? eventModel.AnswerId : throw new AnswerNotFoundException();
            var answer = GetAnswerById(answerId);
            if (answer == null) throw new AnswerNotFoundException();


            /*
            // Вставка тестовой дочерней записи
            answer.Attachments.Add(new AnswerAttachmentEntity()
            {
                Id = Guid.NewGuid(),
                AnswerId = answer.Id,
                Created = DateTime.Now,
                FileName = "Тест фром извне!",
                MimeType = "html/text",
                Size = 1232
            }
            );            
            // Вставка тестовой дочерней записи
            answer.Events.Add(new AnswerEventEntity()
            {
                Id = Guid.NewGuid(),
                AnswerId = answer.Id,
                Value = "Real Test извне",
                ClientTime = DateTime.Now,
                Type = AnswerEventTypeEnumEntity.Other
            }
            );
            */

            //answer.Events = eventModel.Events

            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<AnswerEntity>> GetAll()
        {
            return await _dbContext.Answers.ToListAsync();
        }

        /*
        public void CreateTestDataSet() {
            var answer1Id = Guid.NewGuid();
            var answer2Id = Guid.NewGuid();
            var answer3Id = Guid.NewGuid();

            var q = new QuestionEntity()
            {
                Id = Guid.NewGuid(),
                Text = "What is love?",
                Answers = new List<AnswerEntity>() {
                    new AnswerEntity(){
                        Id= answer1Id,
                        Text = "Babe don't heart me",
                        Events = new List<AnswerEventEntity>(){
                            new AnswerEventEntity(){
                                Id= Guid.NewGuid(),
                                AnswerId= answer1Id,
                                Value = "Launch google",
                                ClientTime = DateTime.Now,
                                Type = AnswerEventTypeEnumEntity.Click
                            }
                        }
                    },
                    new AnswerEntity(){
                        Id= answer2Id,
                        Text = "Don't heart me",
                        Events = new List<AnswerEventEntity>(){
                            new AnswerEventEntity(){
                                Id= Guid.NewGuid(),
                                AnswerId= answer2Id,
                                Value = "Me me e ...",
                                ClientTime = DateTime.Now,
                                Type = AnswerEventTypeEnumEntity.Press
                            },
                            new AnswerEventEntity(){
                                Id= Guid.NewGuid(),
                                AnswerId= answer2Id,
                                Value = "Memee ...",
                                ClientTime = DateTime.Now,
                                Type = AnswerEventTypeEnumEntity.Press
                            }

                        }
                    },
                    new AnswerEntity(){
                        Id = answer3Id,
                        Text = "No more",
                        Attachments = new List<AnswerAttachmentEntity>(){
                            new AnswerAttachmentEntity()
                            {
                                Id= Guid.NewGuid(),
                                AnswerId = answer3Id,
                                Created = DateTime.Now,
                                FileName = "Alexander Haddeway.mp3",
                                MimeType = "application/octeam",
                                Size = 242
                            },
                            new AnswerAttachmentEntity()
                            {
                                Id= Guid.NewGuid(),
                                AnswerId = answer3Id,
                                Created = DateTime.Now,
                                FileName = "Love Song Lyrics.txt",
                                MimeType = "html/text",
                                Size = 172453
                            }

                        }
                    }
                }
            };

            try
            {
                _dbContext.Questions.Add(q);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }

        }
        */

    }
}
