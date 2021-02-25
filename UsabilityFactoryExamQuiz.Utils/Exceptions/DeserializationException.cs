using System;

namespace UsabilityFactoryExamQuiz.Utils.Exceptions
{
    /// <summary>
    /// Ошибки в процессе десериализации
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
