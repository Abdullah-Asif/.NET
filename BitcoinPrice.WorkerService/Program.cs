using Autofac;
using Autofac.Extensions.DependencyInjection;
using BitcoinPrice.Library;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitcoinPrice.WorkerService
{
    public class Program
    {
        private static string _connectionString;
        private static string _migrationAssemblyName;
        public static void Main(string[] args)
        {
            _connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json", false)
                .Build()
                .GetConnectionString("DefaultConnection");
            _migrationAssemblyName = typeof(Worker).Assembly.FullName;
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseWindowsService()
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(builder => {
                builder.RegisterModule(new FrameworkModule(_connectionString, _migrationAssemblyName));
                })
                .ConfigureServices((hostContext, services) =>
                {
                    
                    services.AddHostedService<Worker>();

                });
    }
}
