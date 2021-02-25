using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using UsabilityFactoryExamQuiz.Utils.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;

namespace UsabilityFactoryExamQuiz.Utils.Repositories
{
    /// <summary>
    /// Реализация основных методов работы с хранилищем файлов Azure Storage
    /// </summary>
    public class AzureStorageRepository : IFileRepository
    {
        private readonly IConfiguration _config;

        public AzureStorageRepository(IConfiguration config) {
            _config = config;
        }

        private static BlobContainerClient container;

        private BlobContainerClient BlobContainer
        {
            get
            {
                if (container == null)
                {
                    string connectionString = _config.GetValue<string>("StorageSettings:AzureStorageConnection"); 
                    string containerName = _config.GetValue<string>("StorageSettings:BlobContainerName"); 
                    container = new BlobContainerClient(connectionString, containerName);
                    container.CreateIfNotExists();
                }

                return container;
            }
        }

        /// <summary>
        /// Сохраним файл в виде блоба в Azure Storage
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileContent"></param>
        public void SaveFile(string fileName, IFormFile fileContent)
        {
            using (var stream = fileContent.OpenReadStream())
            {
                BlobClient blob = BlobContainer.GetBlobClient(fileName);
                blob.Upload(stream);
            }
        }

    }
}
