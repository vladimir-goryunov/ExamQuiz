using System;
using System.Collections.Generic;
using System.Text;

namespace UsabilityFactoryExamQuiz.Model.EF.Models
{
    public class AnswerEventEntity
    {
        /// <summary>
        /// Описательная характеристика фиксируемого действия пользователя, 
        /// которое он выполняет при ответе на вопрос
        /// </summary>
        public String Value { get; set; }
        /// <summary>
        /// Тип события
        /// </summary>
        public AnswerEventTypeEnumEntity Type { get; set; }
        /// <summary>
        /// Время наступления события, с учётом TimeZone клиента
        /// </summary>
        public DateTime ClientTime { get; set; }
    }
}
