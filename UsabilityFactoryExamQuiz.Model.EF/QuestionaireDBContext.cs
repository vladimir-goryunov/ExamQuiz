using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
    /// Миграция создание классов и скрипта:
    /// PM> Add-Migration Questionaire
    /// PM> Script-Migration 0 Questionaire
    /// </remarks>
    public class QuestionaireDBContext : DbContext, IQuestionaireDBContext
    {

        public DbSet<QuestionEntity> Questions { get; set; }

        public DbSet<AnswerEntity> Answers { get; set; }

        public QuestionaireDBContext() {            
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public QuestionaireDBContext(DbContextOptions<QuestionaireDBContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }
               


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new QuestionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AnswerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AnswerEventEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AnswerAttachmentEntityConfiguration());
        }


        public void CreateTestDataSet()
        {
            var answer1Id = Guid.NewGuid();
            var answer2Id = Guid.NewGuid();
            var answer3Id = Guid.NewGuid();

            var q = new QuestionEntity()
            {
                Id = Guid.NewGuid(),
                Text = "What is love?",
                Answers = new List<AnswerEntity>() {
                    new AnswerEntity(){
                        Id= answer1Id,
                        Text = "Babe don't heart me",
                        Events = new List<AnswerEventEntity>(){
                            new AnswerEventEntity(){
                                Id= Guid.NewGuid(),
                                AnswerId= answer1Id,
                                Value = "Launch google",
                                ClientTime = DateTime.Now,
                                Type = AnswerEventTypeEnumEntity.Click
                            }
                        }
                    },
                    new AnswerEntity(){
                        Id= answer2Id,
                        Text = "Don't heart me",
                        Events = new List<AnswerEventEntity>(){
                            new AnswerEventEntity(){
                                Id= Guid.NewGuid(),
                                AnswerId= answer2Id,
                                Value = "Me me e ...",
                                ClientTime = DateTime.Now,
                                Type = AnswerEventTypeEnumEntity.Press
                            },
                            new AnswerEventEntity(){
                                Id= Guid.NewGuid(),
                                AnswerId= answer2Id,
                                Value = "Memee ...",
                                ClientTime = DateTime.Now,
                                Type = AnswerEventTypeEnumEntity.Press
                            }

                        }
                    },
                    new AnswerEntity(){
                        Id = answer3Id,
                        Text = "No more",
                        Attachments = new List<AnswerAttachmentEntity>(){
                            new AnswerAttachmentEntity()
                            {
                                Id= Guid.NewGuid(),
                                AnswerId = answer3Id,
                                Created = DateTime.Now,
                                FileName = "Alexander Haddeway.mp3",
                                MimeType = "application/octeam",
                                Size = 242
                            },
                            new AnswerAttachmentEntity()
                            {
                                Id= Guid.NewGuid(),
                                AnswerId = answer3Id,
                                Created = DateTime.Now,
                                FileName = "Love Song Lyrics.txt",
                                MimeType = "html/text",
                                Size = 172453
                            }

                        }
                    }
                }
            };

            try
            {
                this.Questions.Add(q);
                this.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }

        }

    }
}
