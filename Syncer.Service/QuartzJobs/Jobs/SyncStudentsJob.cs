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
    public class SyncStudentsJob : IJob
    {
        private readonly ILogger<SyncStudentsJob> _logger;
        private readonly IPushService _pushService;
        private readonly HeadOfficeConfig _headOfficeConfig;


        public SyncStudentsJob(ILogger<SyncStudentsJob> logger, IPushService pushService, IOptions<HeadOfficeConfig> optionsAccessor)
        {
            _logger = logger;
            _pushService = pushService;
            _headOfficeConfig = optionsAccessor.Value;
        }

        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogWarning("Sync Students Job Started!---------------------------------\n\n");
            _pushService.PushPending<Student>($"{_headOfficeConfig.BaseUrl}Students/BulkCreate");
            _logger.LogInformation("sync Students Job Executed!-------------------------------------\n\n");
            return Task.CompletedTask;
        }
    }
}
