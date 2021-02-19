using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UsabilityFactoryExamQuiz.Model.DataContract;
using UsabilityFactoryExamQuiz.Model.EF.Models;

namespace UsabilityFactoryExamQuiz.Utils.Repositories.Interfaces
{
    public interface IAnswerRepository
    {

        public Task<IEnumerable<AnswerEntity>> GetAll();

        /// <summary>
        /// Сохранить файлы вложений в виде блобов в хранилище Azure Storage в контейнере attachments 
        /// и создать соответствующие записи в SQL базе в таблице AnswerAttachments
        /// </summary>
        /// <returns></returns>
        public void SaveAnswerAttachments(AttachmentModel attachmentModel);

        /// <summary>
        /// Сохранить события в SQL базе данных в таблице AnswerEvents
        /// </summary>
        /// <returns></returns>
        public void SaveAnswerEvents(EventModel eventModel);

    }
}
