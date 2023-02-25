using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

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
