using Aqary.Core.Factory;
using Microsoft.Extensions.DependencyInjection;

namespace Aqary.Factory
{
    public class ApiFactory
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            DataManagerFactory.RegisterDependencies(services);
        }
    }
}
