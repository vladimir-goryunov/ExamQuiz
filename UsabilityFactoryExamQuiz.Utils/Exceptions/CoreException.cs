using System;

namespace UsabilityFactoryExamQuiz.Utils.Exceptions
{
    /// <summary>
    /// Проблемы при работе приложения
    /// </summary>
    public class CoreException : Exception
    {
        public CoreException()
        {
        }

        public CoreException(string? message)
            : base(message) { }

        public CoreException(string? message, Exception? innerException)
            : base(message, innerException) { }
    }
}
