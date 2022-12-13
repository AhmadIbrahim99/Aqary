using Aqary.Infrastructure.Factory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aqary.Core.Factory
{
    public class DataManagerFactory
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            InfrastructureFactory.RegisterDependencies(services);
            

            Assembly assembly = typeof(DataManagerFactory).GetTypeInfo().Assembly;

            //var allRepository = assembly.GetTypes().Where(t => t.Name.EndsWith("Repository"));

            //foreach (var type in allRepository)
            //{
            //    var allInterfaces = type.GetInterfaces();
            //    var mainInterfaces = allInterfaces.Except(allInterfaces.SelectMany(t => t.GetInterfaces()));
            //    foreach (var itype in mainInterfaces)
            //    {
            //        services.AddScoped(itype, type);
            //    }
            //}

            var allManagers = assembly.GetTypes().Where(t => t.Name.EndsWith("Manager"));

            foreach (var type in allManagers)
            {
                var allInterfaces = type.GetInterfaces();
                var mainInterfaces = allInterfaces.Except(allInterfaces.SelectMany(t => t.GetInterfaces()));
                foreach (var itype in mainInterfaces)
                {
                    services.AddScoped(itype, type);
                }
            }
        }
    }
}
