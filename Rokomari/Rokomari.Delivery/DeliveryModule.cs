using Autofac;
using Rokomari.Delivery.Contexts;
using Rokomari.Delivery.UnitOfWorks;
using Rokomari.Delivery.Repositories.cs;
using Rokomari.Delivery.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rokomari.Delivery
{
    public class DeliveryModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        public DeliveryModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<DeliveryContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<DeliveryContext>().As<IDeliveryContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<BookService>().As<IBookService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BookRepository>().As<IBookRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DeliveryUnitOfWork>().As<IDeliveryUnitOfWork>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
