using System;
using System.Collections.Generic;

namespace UsabilityFactoryExamQuiz.Model
{
    /// <summary>
    /// Ответ на вопрос
    /// </summary>
    public class Answer
    {
        /// <summary>
        /// Идентификатор ответа
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Текст вопроса
        /// </summary>
        public String Text { get; set; }

        /// <summary>
        /// Действия пользователя при ответе на вопрос
        /// </summary>
        public List<AnswerEvent> Events { get; set; }

        /// <summary>
        /// Файлы вложений, относящихся к ответу на вопрос
        /// </summary>
        public List<AnswerAttachment> Attachments { get; set; }
    }
}
