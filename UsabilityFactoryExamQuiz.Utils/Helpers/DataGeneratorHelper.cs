using System;
using System.Collections.Generic;
using UsabilityFactoryExamQuiz.Model.EF.Models;

namespace UsabilityFactoryExamQuiz.Utils.Helpers
{
    /// <summary>
    /// Генерация данных для приложения
    /// </summary>
    public static class DataGeneratorHelper
    {
        static string GetRandomPhrase() {
            var phrases = new List<String>() {
                "Перемещение влево",
                "Перемещение вправо",
                "Щелчок мыши",
                "Перемещение курсора по экрану",
                "Перетаскивание объекта на экране",
                "Нажатие клавиши",
                "243",
                "Нажатие клавиши ENTER",
                "Нажатие клавиши ESC",
                "Пользователь не двигает курсор более 5 минут"
            };

            Random rnd = new Random();
            return phrases[rnd.Next(0, phrases.Count)];
        }

        static AnswerEventTypeEnumEntity GetRandomAnswerEventType()
        {
            Random rnd = new Random();
            return (AnswerEventTypeEnumEntity) rnd.Next(5);
        }

        static DateTime GetRandomDateTime()
        {
            Random rnd = new Random();
            return DateTime.Now.AddMinutes(rnd.Next(1,60));
        }

        static AnswerEventEntity GenerateEvent(Guid answerId)
        {
            return new AnswerEventEntity()
            {
                Id = Guid.NewGuid(),
                AnswerId = answerId,
                Value = GetRandomPhrase(),
                ClientTime = GetRandomDateTime(),
                Type = GetRandomAnswerEventType()
            };
        }

        public static List<AnswerEventEntity> GenerateEvents(Guid answerId) {

            Random rnd = new Random();
            var events = new List<AnswerEventEntity>();

            for (int index = 0; index< rnd.Next(1,11); index++) {
                events.Add(GenerateEvent(answerId));
            }

            return events;
        }

    }
}
