﻿using System;

namespace UsabilityFactoryExamQuiz.Utils.Exceptions
{
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
