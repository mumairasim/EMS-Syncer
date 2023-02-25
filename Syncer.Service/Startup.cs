using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using Syncer.Data.DatabaseContext;
using Syncer.Data.Implementation;
using Syncer.Data.Interface;
using Syncer.Service.Configurations;
using Syncer.Service.QuartzJobs;
using Syncer.Service.QuartzJobs.Jobs;
using Syncer.Service.Services.Implementation;
using Syncer.Service.Services.Interface;
using System.IO;

namespace Syncer.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);
            IConfiguration config = builder.Build();
            var smsConnectionString = config.GetConnectionString("SMSDB");
            services.AddDbContext<SMSContext>(options => options.UseSqlServer(smsConnectionString), ServiceLifetime.Singleton);

            services.AddSingleton<IRepository, Repository>();
            services.AddSingleton<IClassService, ClassService>();
            services.AddHttpContextAccessor();
            //services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();


            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            services.AddHostedService<QuartzHostedService>();
            var configuration = config
                .GetSection("Quartz")
                .Get<QuartzConfiguration>();
            services.AddSingleton(configuration);


            #region Jobs

            services.AddSingleton<SyncClassesJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(SyncClassesJob),
                cronExpression: configuration.SyncClassesJobTimeInterval));

            #endregion

            services.AddControllersWithViews();
        }

        //This method gets called by the runtime.Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.Run(async (context) =>
             {
                 await context.Response.WriteAsync("SMS Service Started");
             });
        }
    }
}
