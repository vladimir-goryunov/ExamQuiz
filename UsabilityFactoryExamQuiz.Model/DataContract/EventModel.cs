using System;
using System.Collections.Generic;
using UsabilityFactoryExamQuiz.Model.BusinessLogic;
using UsabilityFactoryExamQuiz.Model.EF.Models;

namespace UsabilityFactoryExamQuiz.Model.DataContract
{
    public class EventModel
    {
        /// <summary>
        /// Идентификатор ответа, к которому относятся события
        /// </summary>
        public Guid AnswerId { get; set; }

        /// <summary>
        /// Строка JSON c массивом событий
        /// </summary>
        public String EventsJson { get; set; }

        /// <summary>
        /// Массив событий, приложенные к ответу
        /// </summary>
        public List<AnswerEventEntity> Events { get; set; }


        public EventModel() { 
        }

        public EventModel(Guid answerId)
        {
            AnswerId = answerId;
        }

        public EventModel(Guid answerId, String eventsJson) {
            AnswerId = answerId;
            EventsJson = eventsJson;
        }
    }
}
