using Microsoft.Extensions.Logging;
using Quartz;
using Syncer.Data.Entities;
using Syncer.Service.Services.Interface;
using System.Threading.Tasks;

namespace Syncer.Service.QuartzJobs.Jobs
{
    [DisallowConcurrentExecution]
    public class SyncClassesJob : IJob
    {
        private readonly ILogger<SyncClassesJob> _logger;
        private readonly IPushService _pushService;

        public SyncClassesJob(ILogger<SyncClassesJob> logger, IPushService pushService)
        {
            _logger = logger;
            _pushService = pushService;
        }



        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogWarning("Sync Classes Job Started!---------------------------------\n\n");
            _pushService.PushPending<Class>("http://localhost:44358/api/v1/Class/BulkCreate");
            //_classService.PushPending();
            _logger.LogInformation("sync classes Job Executed!-------------------------------------\n\n");
            return Task.CompletedTask;
        }
    }
}
