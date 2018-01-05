using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Extensions.Logging;
using Quik.Framework.Entity.DbContext;
using Module = Autofac.Module;

namespace Quik.Framework.Autofac
{
    public class AutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //AppService注入
            builder.RegisterAssemblyTypes(Assembly.Load("Quik.Framework.AppService"))
                .Where(t => t.Name.EndsWith("AppService")).AsSelf().AsImplementedInterfaces();
            builder.RegisterType(typeof(SqlSugarDbContext)).As(typeof(ISqlSugarDbContext))
                .InstancePerLifetimeScope();
        }
    }
}
