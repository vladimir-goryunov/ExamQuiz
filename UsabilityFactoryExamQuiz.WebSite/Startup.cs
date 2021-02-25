using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UsabilityFactoryExamQuiz.Model.EF;
using UsabilityFactoryExamQuiz.Utils.Repositories;
using UsabilityFactoryExamQuiz.Utils.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using UsabilityFactoryExamQuiz.Model.EF.Models;
using System.Collections.Generic;

namespace UsabilityFactoryExamQuiz.WebSite
{
    public class Startup
    {
        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            Configuration = configuration;
            LoggerFactory = loggerFactory;
        }

        public IConfiguration Configuration { get; }
        public ILoggerFactory LoggerFactory { get; }

        /// <summary>
        /// Конфигурируем сервисы
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddLogging(logging => logging.AddDebug());
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "ExamQuiz REST API" });
            });
            services.AddSwaggerGenNewtonsoftSupport();

            AddDb(services);
        }

        /// <summary>
        /// Конфигурируем приложение
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ExamQuiz REST API");
            });

            PopulateDatabaseWithTestData(app);
        }

        /// <summary>
        /// Добавим данных в БД
        /// </summary>
        /// <param name="app"></param>
        private static void PopulateDatabaseWithTestData(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<IQuestionaireDBContext>())
                {
                    CreateTestDataSet(context);
                }
            }
        }

        /// <summary>
        /// Настройка зависимостей
        /// </summary>
        /// <param name="services"></param>
        private void AddDb(IServiceCollection services)
        {
            services.AddDbContext<IQuestionaireDBContext, QuestionaireDBContext>(opts =>
                opts.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")),
                ServiceLifetime.Transient);

            services.AddTransient<IAnswerRepository, AnswerRepository>(); 
            services.AddTransient<IFileRepository, AzureStorageRepository>();
        }

        /// <summary>
        /// Создаем тестовый набор данных
        /// </summary>
        private static void CreateTestDataSet(IQuestionaireDBContext _dbContext)
        {
            var answer1Id = Guid.NewGuid();
            var answer2Id = Guid.NewGuid();
            var answer3Id = Guid.NewGuid();

            var q = new QuestionEntity()
            {
                Id = Guid.NewGuid(),
                Text = "What is Spring?",
                Answers = new List<AnswerEntity>() {
                    new AnswerEntity(){
                        Id= answer1Id,
                        Text = "Java framework",
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
                        Text = "Time of the year",
                        Events = new List<AnswerEventEntity>(){
                            new AnswerEventEntity(){
                                Id= Guid.NewGuid(),
                                AnswerId= answer2Id,
                                Value = "Trying to type something",
                                ClientTime = DateTime.Now,
                                Type = AnswerEventTypeEnumEntity.Press
                            },
                            new AnswerEventEntity(){
                                Id= Guid.NewGuid(),
                                AnswerId= answer2Id,
                                Value = "This is additional words",
                                ClientTime = DateTime.Now,
                                Type = AnswerEventTypeEnumEntity.Press
                            }

                        }
                    },
                    new AnswerEntity(){
                        Id = answer3Id,
                        Text = "Is a brand of water",
                        Attachments = new List<AnswerAttachmentEntity>(){
                            new AnswerAttachmentEntity()
                            {
                                Id= Guid.NewGuid(),
                                AnswerId = answer3Id,
                                Created = DateTime.Now,
                                FileName = "Bottle.mp3",
                                MimeType = "application/octeam",
                                Size = 242
                            },
                            new AnswerAttachmentEntity()
                            {
                                Id= Guid.NewGuid(),
                                AnswerId = answer3Id,
                                Created = DateTime.Now,
                                FileName = "Spring is around.txt",
                                MimeType = "html/text",
                                Size = 172453
                            }

                        }
                    }
                }
            };

            try
            {
                _dbContext.Questions.Add(q);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }

        }

    }
}
