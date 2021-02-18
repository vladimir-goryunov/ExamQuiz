using System;

namespace UsabilityFactoryExamQuiz.Utils.Responses
{
    /// <summary>
    /// Сообщение об ответе сервера о выполнении метода
    /// </summary>
    public class ResponseMessage
    {
        /// <summary>
        /// User-friendly заголовок ответа
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// User-friendly текст ответа
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Техническая инфо - описание ошибки
        /// </summary>
        public string Exception { get; set; }
        /// <summary>
        /// Статус выполнения метода
        /// </summary>
        public Int32 HttpCode { get; set; } = (int)System.Net.HttpStatusCode.OK;

        public ResponseMessage()
        {
        }

        public ResponseMessage(string title, string text)
        {
            Title = title;
            Text = text;
        }

        public ResponseMessage(string title, string text, Int32 httpCode) 
            : this(title, text)
        {
            HttpCode = httpCode;
        }

        public ResponseMessage(string title, string text, string exception, int httpCode) 
            : this(title, text)
        {
            Exception = exception;
            HttpCode = httpCode;
        }
    }
}
