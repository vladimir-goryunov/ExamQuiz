using System;

namespace UsabilityFactoryExamQuiz.Utils.Exceptions
{
    /// <summary>
    /// Исключение - ошибка десериализации
    /// </summary>
    public class DeserializationException : Exception
    {

        public DeserializationException() { 
        }

        public DeserializationException(string? message) 
            : base(message) { }

        public DeserializationException(string? message, Exception? innerException) 
            : base(message, innerException) { }

    }
}
