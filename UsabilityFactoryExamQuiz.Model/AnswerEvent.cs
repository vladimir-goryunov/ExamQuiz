using System;

namespace UsabilityFactoryExamQuiz.Model
{
    /// <summary>
    /// Событие, описывающее действие пользователя при ответе на вопрос
    /// </summary>
    public class AnswerEvent
    {
        /// <summary>
        /// Описательная характеристика фиксируемого действия пользователя, 
        /// которое он выполняет при ответе на вопрос
        /// </summary>
        String Value { get; set; }
        /// <summary>
        /// Тип события
        /// </summary>
        AnswerEventTypeEnum Type { get; set; }
        /// <summary>
        /// Время наступления события, с учётом TimeZone клиента
        /// </summary>
        DateTime ClientTime { get; set; }
    }
}
