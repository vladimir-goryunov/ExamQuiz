using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using UsabilityFactoryExamQuiz.Model.EF.Models;

namespace UsabilityFactoryExamQuiz.Model.EF
{
    public interface IQuestionaireDBContext : IDisposable
    {
        DbSet<QuestionEntity> Questions { get; }
        /// <summary>
        /// Ответы 
        /// </summary>
        DbSet<AnswerEntity> Answers { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
