using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using UsabilityFactoryExamQuiz.Model.DataContract;

namespace UsabilityFactoryExamQuiz.Utils.Repositories.Interfaces
{
    public interface IFileRepository
    {
        public void SaveFiles(IEnumerable<IFormFile> files);
    }
}
