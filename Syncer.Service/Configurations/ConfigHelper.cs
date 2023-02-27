using Microsoft.Extensions.Configuration;

namespace Syncer.Service.Configurations
{
    public static class ConfigHelper
    {
        public static QuartzConfiguration QuartzConfigurationSettings(IConfiguration config)
        {
            var settings = config.GetSection("Quartz").Get<QuartzConfiguration>();
            return settings;
        }
    }
}
