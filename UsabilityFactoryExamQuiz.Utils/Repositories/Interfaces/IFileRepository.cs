using Microsoft.AspNetCore.Http;

namespace UsabilityFactoryExamQuiz.Utils.Repositories.Interfaces
{
    public interface IFileRepository
    {
        void SaveFile(string fileName, IFormFile fileContent);
    }
}
