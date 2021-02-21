using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using UsabilityFactoryExamQuiz.Utils.Repositories.Interfaces;

namespace UsabilityFactoryExamQuiz.Utils.Repositories
{
    public class AzureStorageRepository : IFileRepository
    {
        private BlobContainerClient container;

        string connectionString = "DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10001/devstoreaccount1;";
        string containerName = "attachments";

        protected const string SampleFileContent = @"Тестовый текст. Lorem ipsum dolor sit amet";

        static string CreateTempPath(string extension = ".txt") =>
            Path.ChangeExtension(Path.GetTempFileName(), extension);

        static string Randomize(string prefix = "sample") =>
            $"{prefix}-{Guid.NewGuid()}";

        static string CreateTempFile(string content = SampleFileContent)
        {
            string path = CreateTempPath();
            File.WriteAllText(path, content);
            return path;
        }

        private BlobContainerClient BlobContainer
        {
            get
            {
                if (container == null)
                {
                    container = new BlobContainerClient(connectionString, containerName);
                    container.CreateIfNotExists();
                }

                return container;
            }
        }

        public void SaveFiles(IEnumerable<IFormFile> files)
        {
            foreach (var file in files)
            {
                using (var stream = file.OpenReadStream())
                {
                    string blobName = Guid.NewGuid().ToString("N") + file.FileName;
                    BlobClient blob = BlobContainer.GetBlobClient(blobName);
                    blob.Upload(stream);

                    System.Diagnostics.Debug.WriteLine(blob.Name + " added to Azure...");
                }
            }
        }
    }
}
