using Microsoft.Extensions.Logging;
using Quartz;
using Syncer.Data.Entities;
using Syncer.Service.Services.Interface;
using System.Threading.Tasks;

namespace Syncer.Service.QuartzJobs.Jobs
{
    [DisallowConcurrentExecution]
    public class SyncCoursesJob : IJob
    {
        private readonly ILogger<SyncCoursesJob> _logger;
        private readonly IPushService _pushService;

        public SyncCoursesJob(ILogger<SyncCoursesJob> logger, IPushService pushService)
        {
            _logger = logger;
            _pushService = pushService;
        }



        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogWarning("Sync Courses Job Started!---------------------------------\n\n");
            _pushService.PushPending<Course>("http://localhost:44358/api/v1/Course/BulkCreate");
            _logger.LogInformation("sync Courses Job Executed!-------------------------------------\n\n");
            return Task.CompletedTask;
        }
    }
}
