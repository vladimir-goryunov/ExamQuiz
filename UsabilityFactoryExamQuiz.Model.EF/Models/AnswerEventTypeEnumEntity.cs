using System;
using System.Collections.Generic;
using System.Text;

namespace UsabilityFactoryExamQuiz.Model.EF.Models
{
    /// <summary>
    /// Модель сущность типов событий
    /// </summary>
    public enum AnswerEventTypeEnumEntity
    {
        /// <summary>
        /// Щелчок мыши 
        /// </summary>
        Click,
        /// <summary>
        /// Перемещение курсора по экрану
        /// </summary>
        Move,
        /// <summary>
        /// Перетаскивание объекта на экране
        /// </summary>
        Drag,
        /// <summary>
        /// Нажатие клавиши 
        /// </summary>
        Press,
        /// <summary>
        /// Иной вид события
        /// </summary>
        Other
    }
}
