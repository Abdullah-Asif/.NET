using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestConfig.Services;

namespace TestConfig
{
    public class WebModule : Module
    {



        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SimpleDatabaseService>().As<IDatabaseService>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}