using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsabilityFactoryExamQuiz.Model.EF;
using UsabilityFactoryExamQuiz.Model.EF.Models;
using UsabilityFactoryExamQuiz.Utils.Exceptions;
using UsabilityFactoryExamQuiz.Utils.Repositories.Interfaces;

namespace UsabilityFactoryExamQuiz.Utils.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly IQuestionaireDBContext _dbContext;

        public AnswerRepository(IQuestionaireDBContext context)
        {
            _dbContext = context;
        }

        /// <summary>
        /// Ищем в БД answer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private AnswerEntity GetAnswer(Guid id) {
            return _dbContext.Answers.FirstOrDefault(u => u.Id.Equals(id));
        }

        public void SaveAnswerAttachments(Guid id)
        {   
            var answer = GetAnswer(id);
            if (answer == null) throw new AnswerNotFoundException();

            // TODO - добавить сохранение
        }

        public void SaveAnswerEvents(Guid id)
        {
            var answer = GetAnswer(id);
            if (answer == null) throw new AnswerNotFoundException();

            // TODO - добавить сохранение
        }

    }
}
