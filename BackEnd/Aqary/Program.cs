using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Aqary
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                            .ConfigureWebHostDefaults(webHostBuilder => {
                                webHostBuilder
                                      .UseContentRoot(Directory.GetCurrentDirectory())
                                      .UseIISIntegration()
                                      .UseStartup<Startup>();
                            })
                            .Build();
            host.Run();
            return 0;
        }
    }
}
