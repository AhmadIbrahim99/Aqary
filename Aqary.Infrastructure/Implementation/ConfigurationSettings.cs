using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqary.Infrastructure.Implementation
{
    public class ConfigurationSettings : IConfigurationSettings
    {
        #region Private Variables
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _env;
        #endregion Private Variables

        public ConfigurationSettings(IWebHostEnvironment env, IConfiguration config)
        {
            _config = config;
            _env = env;
        }

        public string JwtKey => _config["Jwt:Key"];

        public string Issure => _config["Jwt:Issure"];

        //public string WebSiteURl => _config["URL:WebSiteURl"];

    }
}
