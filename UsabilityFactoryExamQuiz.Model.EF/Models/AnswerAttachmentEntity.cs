using System;
using System.Collections.Generic;
using System.Text;

namespace UsabilityFactoryExamQuiz.Model.EF.Models
{
    /// <summary>
    /// Модель сущность вложений к ответу
    /// </summary>
    public class AnswerAttachmentEntity
    {
        /// <summary>
        /// Идентификатор вложения
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Идентификатор ответа, к которому относится загруженное вложение
        /// </summary>
        public Guid AnswerId { get; set; }
        /// <summary>
        /// Время создания 
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Имя файла вложения
        /// </summary>
        public String FileName { get; set; }
        /// <summary>
        /// Тип файла вложения
        /// </summary>
        public String MimeType { get; set; }
        /// <summary>
        /// Размер файла вложения
        /// </summary>
        public Int32 Size { get; set; }



        public AnswerAttachmentEntity() { }

        public AnswerAttachmentEntity(Guid answerId) {
            AnswerId = answerId;
        }
    }
}
