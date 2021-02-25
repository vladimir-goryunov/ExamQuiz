using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace UsabilityFactoryExamQuiz.Model.DataContract
{
    /// <summary>
    /// Data Contract для модели вложений к ответу
    /// </summary>
    public class AttachmentModel
    {
        /// <summary>
        /// Идентификатор ответа, к которому относятся приложения
        /// </summary>
        public Guid AnswerId { get; set; }

        /// <summary>
        /// Файлы, приложенные к ответу
        /// </summary>
        /// <remarks>
        /// Microsoft удалила класс HttpPostedFileBase из ASP.Net Core 
        /// Для загрузки файлов в ASP.Net Core 2.0 и ASP.Net Core 3.0
        /// следует использовать интерфейс IFormFile 
        /// </remarks>
        public IEnumerable<IFormFile> Files { get; set; }

        public AttachmentModel() { 
        }

        public AttachmentModel(Guid answerId) {
            AnswerId = answerId;
        }

        public AttachmentModel(Guid answerId, IEnumerable<IFormFile> files)
        {
            AnswerId = answerId;
            Files = files;
        }
    }
}
