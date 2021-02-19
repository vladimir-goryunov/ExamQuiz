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

namespace UsabilityFactoryExamQuiz.Utils.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly IQuestionaireDBContext _dbContext;
        private readonly IFileRepository _attachmentRepository;

        public AnswerRepository(IQuestionaireDBContext context, IFileRepository attachmentRepository)
        {
            _dbContext = context;
            _attachmentRepository = attachmentRepository;
        }

        /// <summary>
        /// Ищем в БД ответ по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private AnswerEntity GetAnswer(Guid id) {
            return _dbContext.Answers.FirstOrDefault(u => u.Id.Equals(id));
        }

        public void SaveAnswerAttachments(AttachmentModel attachmentModel)
        {
            Guid answerId = attachmentModel != null ? attachmentModel.AnswerId : throw new AnswerNotFoundException();
            AnswerEntity answer = GetAnswer(answerId);
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
                    answer.Attachments.Add(attachment);
                }
                else
                {
                    files.Remove(file);
                }
            }

            try
            {
                _attachmentRepository.SaveFiles(attachmentModel.Files);
                _dbContext.SaveChanges(); // Обновляем answer после добавления аттачей
            }
            catch (Exception ex) { 
                // Rollback all files!!!
            }

        }

        public void SaveAnswerEvents(EventModel eventModel)
        {
            Guid answerId = eventModel != null ? eventModel.AnswerId : throw new AnswerNotFoundException();
            var answer = GetAnswer(answerId);
            if (answer == null) throw new AnswerNotFoundException();

            //answer.Events = eventModel.Events
            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<AnswerEntity>> GetAll()
        {
            var entities = await _dbContext.Answers.ToListAsync();
            return entities;
        }

    }
}
