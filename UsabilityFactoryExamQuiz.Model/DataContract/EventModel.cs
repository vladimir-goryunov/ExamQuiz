using System;
using System.Collections.Generic;
using UsabilityFactoryExamQuiz.Model.BusinessLogic;

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
        public String AnswerEventsJSON { get; set; }

        /// <summary>
        /// Массив событий, приложенные к ответу
        /// </summary>
        public List<AnswerEvent> Events {
            get { 
                return new List<AnswerEvent>(); 
            }  
        }

        private AnswerEvent[] ToEvents(string eventsJson) {
            return null;
        }
        public EventModel() { 
        }

        public EventModel(Guid answerId)
        {
            AnswerId = answerId;
        }

        public EventModel(Guid answerId, String answerEventsJSON) {
            AnswerId = answerId;
            AnswerEventsJSON = answerEventsJSON;
        }
    }
}
