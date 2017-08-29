using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using Quik.Framework;
using Quik.Framework.DbContext;


namespace Quik.Framework
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // 控制器注入
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // 过滤器注入
            builder.RegisterFilterProvider();

            // 视图注入
            //builder.RegisterSource(new ViewRegistrationSource());

            // Register our Data dependencies
            //builder.RegisterModule(new DataModule("MVCWithAutofacDB"));

            //AppService注入
            builder.RegisterAssemblyTypes(Assembly.Load("Quik.Framework.AppService")).Where(t => t.Name.EndsWith("AppService")).AsSelf().AsImplementedInterfaces();

            //单个注入
            //builder.RegisterInstance(new UserAppService()).As<IUserAppService>();
            builder.RegisterType(typeof(MySqlSugarDbContext)).As(typeof(IMySqlSugarDbContext)).InstancePerLifetimeScope();

            var container = builder.Build();

            // Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        //public static void AutofacInitlize()
        //{
        //    AutofacContainer.Initialize();
        //}
    }
}