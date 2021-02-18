﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;
using UsabilityFactoryExamQuiz.Model.EF.Models;
using UsabilityFactoryExamQuiz.Model.EF.Models.Configuration;

namespace UsabilityFactoryExamQuiz.Model.EF
{
    /// <summary>
    /// БД-контекст приложения
    /// </summary>
    /// <remarks>
    /// Миграция:
    /// PM> Add-Migration Questionaire
    /// PM> Script-Migration 0 Questionaire
    /// </remarks>
    public class QuestionaireDBContext : DbContext, IQuestionaireDBContext
    {
        private readonly StreamWriter logStream = new StreamWriter("applog.txt", true);

        public DbSet<QuestionEntity> Questions { get; set; }

        public DbSet<AnswerEntity> Answers { get; set; }

        public QuestionaireDBContext() {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public QuestionaireDBContext(DbContextOptions<QuestionaireDBContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.LogTo(logStream.WriteLine);
            //optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            //optionsBuilder.LogTo(System.Console.WriteLine);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new QuestionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AnswerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AnswerEventEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AnswerAttachmentEntityConfiguration());
        }

        public override void Dispose()
        {
            base.Dispose();
            logStream.Dispose();
        }

        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            await logStream.DisposeAsync();
        }
    }
}
