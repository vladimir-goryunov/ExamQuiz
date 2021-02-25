using Microsoft.AspNetCore.Http;

namespace UsabilityFactoryExamQuiz.Utils.Repositories.Interfaces
{
    /// <summary>
    /// Основные методы для работы с хранилищем файлов
    /// </summary>
    public interface IFileRepository
    {
        /// <summary>
        /// Сохраним файл в виде блоба в Azure Storage
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileContent"></param>
        void SaveFile(string fileName, IFormFile fileContent);
    }
}
