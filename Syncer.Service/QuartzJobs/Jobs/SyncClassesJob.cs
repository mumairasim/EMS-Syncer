using Microsoft.Extensions.Logging;
using Quartz;
using Syncer.Service.Services.Interface;
using System.Threading.Tasks;

namespace Syncer.Service.QuartzJobs.Jobs
{
    [DisallowConcurrentExecution]
    public class SyncClassesJob : IJob
    {
        private readonly ILogger<SyncClassesJob> _logger;
        private readonly IClassService _classService;

        public SyncClassesJob(ILogger<SyncClassesJob> logger, IClassService classService)
        {
            _logger = logger;
            _classService = classService;
        }



        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogWarning("Sync Classes Job Started!---------------------------------\n\n");
            _classService.PushPending();
            _logger.LogInformation("sync classes Job Executed!-------------------------------------\n\n");
            return Task.CompletedTask;
        }
    }
}
