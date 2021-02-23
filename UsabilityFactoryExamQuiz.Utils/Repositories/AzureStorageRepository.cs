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
        private static BlobContainerClient container;

        string connectionString = "DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10001/devstoreaccount1;";
        string containerName = "attachments";

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
