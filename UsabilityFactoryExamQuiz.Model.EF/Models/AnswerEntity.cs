using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsabilityFactoryExamQuiz.Model.EF.Models
{
    public class AnswerEntity
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
        [NotMapped]
        public virtual List<AnswerEventEntity> Events { get; set; }

        /// <summary>
        /// Файлы вложений, относящихся к ответу на вопрос
        /// </summary>
        public virtual List<AnswerAttachmentEntity> Attachments { get; set; }
    }
}
