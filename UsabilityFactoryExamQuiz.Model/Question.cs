using System;
using System.Collections.Generic;
using System.Text;

namespace UsabilityFactoryExamQuiz.Model
{
    /// <summary>
    /// Вопрос анкетирования
    /// </summary>
    public class Question
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
        public List<Answer> Answers { get; set; }
    }
}
