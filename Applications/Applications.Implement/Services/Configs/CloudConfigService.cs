using Infrastructures.Implement.Services.Configs;
using Infrastructures.Models.Configs;
using Microsoft.Extensions.Configuration;

namespace Applications.Implement.Services.Configs
{
    public class CloudConfigService : IConfigService<CloudConfig>
    {
        /// <summary>
        /// 2 case handle but in case will improve performance.
        /// </summary>
        //private static CloudConfig CONFIG;
        //private CloudConfig _cloudConfig { get { return CONFIG; } }

        private static Lazy<CloudConfig> CONFIG = new Lazy<CloudConfig>();

        private readonly IConfiguration _configuration;

        public CloudConfigService(IConfiguration configuration)
        {
            _configuration = configuration;

            //if (_cloudConfig == null)
            //{
            //    {
            //        CONFIG = new CloudConfig
            //        {
            //            Id = _configuration.GetSection("Configs:Id")?.Value,
            //            SerectKey = _configuration.GetSection("Configs:SerectKey")?.Value,
            //        };
            //    }
            //}

            if (!CONFIG.IsValueCreated)
            {
                CONFIG = new Lazy<CloudConfig>(new CloudConfig
                {
                    Id = _configuration.GetSection("Configs:Id")?.Value,
                    SerectKey = _configuration.GetSection("Configs:SerectKey")?.Value,
                });
            }
        }

        //public CloudConfig GetConfig() => _cloudConfig;
        public CloudConfig GetConfig() => CONFIG.Value;
    }
}
