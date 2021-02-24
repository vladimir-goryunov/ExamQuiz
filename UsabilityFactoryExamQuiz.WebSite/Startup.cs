using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsabilityFactoryExamQuiz.Model.EF;
using UsabilityFactoryExamQuiz.Utils.Helpers;
using UsabilityFactoryExamQuiz.Utils.Repositories;
using UsabilityFactoryExamQuiz.Utils.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddLogging(logging => logging.AddDebug());

            AddDb(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
        }

        private void AddDb(IServiceCollection services)
        {
            services.AddDbContext<IQuestionaireDBContext, QuestionaireDBContext>(opts =>
                opts.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")),
                ServiceLifetime.Transient);

            services.AddTransient<IAnswerRepository, AnswerRepository>(); 
            services.AddTransient<IFileRepository, AzureStorageRepository>();
        }
    }
}
