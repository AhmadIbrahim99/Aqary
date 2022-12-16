using Aqary.Infrastructure.Implementation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aqary.Infrastructure.Factory
{
    public class InfrastructureFactory
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddScoped<IConfigurationSettings, ConfigurationSettings>();
        }
    }
}
