using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitcoinPrice.Library
{
    public class FrameworkModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public FrameworkModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BitCoinContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();


            builder.RegisterType<BitCoinPriceRepository>().As<IBitCoinPriceRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BitCoinUnitOfWork>().As<IBitCoinUnitOfWork>()
                .InstancePerLifetimeScope();
                     

            base.Load(builder);
        }
    }

}
