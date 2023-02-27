using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Quartz;
using Syncer.Data.Entities;
using Syncer.Service.Configurations;
using Syncer.Service.Services.Interface;
using System.Threading.Tasks;

namespace Syncer.Service.QuartzJobs.Jobs
{
    [DisallowConcurrentExecution]
    public class SyncLessonPlansJob : IJob
    {
        private readonly ILogger<SyncLessonPlansJob> _logger;
        private readonly IPushService _pushService;
        private readonly HeadOfficeConfig _headOfficeConfig;


        public SyncLessonPlansJob(ILogger<SyncLessonPlansJob> logger, IPushService pushService, IOptions<HeadOfficeConfig> optionsAccessor)
        {
            _logger = logger;
            _pushService = pushService;
            _headOfficeConfig = optionsAccessor.Value;
        }

        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogWarning("Sync Lesson Plans Job Started!---------------------------------\n\n");
            _pushService.PushPending<LessonPlan>($"{_headOfficeConfig.BaseUrl}LessonPlan/BulkCreate");
            _logger.LogInformation("sync Lesson Plans Job Executed!-------------------------------------\n\n");
            return Task.CompletedTask;
        }
    }
}
