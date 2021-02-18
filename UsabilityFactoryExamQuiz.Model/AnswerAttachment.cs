using System;

namespace UsabilityFactoryExamQuiz.Model
{
    /// <summary>
    /// Вложение, загруженное пользователем при ответе на вопрос
    /// </summary>
    public class AnswerAttachment
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
    }
}
