namespace UsabilityFactoryExamQuiz.Model.BusinessLogic
{
    /// <summary>
    /// Фиксируемые в системе типы действий пользователя при ответе на вопрос
    /// </summary>
    public enum AnswerEventTypeEnum
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
