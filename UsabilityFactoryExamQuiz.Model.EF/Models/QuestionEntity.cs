using System;
using System.Collections.Generic;
using System.Text;

namespace UsabilityFactoryExamQuiz.Model.EF.Models
{
    public class QuestionEntity
    {
        /// <summary>
        /// Идентификатор вопроса
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Текст вопроса
        /// </summary>
        public String Text { get; set; }
        /// <summary>
        /// Варианты ответов на вопрос
        /// </summary>
        public virtual List<AnswerEntity> Answers { get; set; }
    }
}
