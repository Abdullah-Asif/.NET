using System;
using Autofac;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rokomari.Web.Areas.Admin.Models;

namespace Rokomari.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookListModel>().AsSelf()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
