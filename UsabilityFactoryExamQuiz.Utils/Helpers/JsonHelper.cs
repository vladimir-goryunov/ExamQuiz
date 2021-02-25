using Newtonsoft.Json;
using System;
using UsabilityFactoryExamQuiz.Utils.Exceptions;

namespace UsabilityFactoryExamQuiz.Utils.Helpers
{
    /// <summary>
    /// Расширение для работы с JSON
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class JsonHelper<T> where T : new()
    {
        /// <summary>
        /// Воссоздаёт объект из JSON строки
        /// </summary>
        /// <param name="json">JSON строка, представляющая объект</param>
        /// <returns></returns>
        public static T CreateFromJSON(string json)
        {   
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                throw new DeserializationException($"Ошибка при попытке десериализации - {ex.Message}", ex);
            }

        }
    }
}
