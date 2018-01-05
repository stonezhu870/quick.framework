using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog.Web;
using Microsoft.AspNetCore.Authentication.Cookies;
using Quik.Framework.Autofac;
using Quik.Framework.Entity.DbContext;

namespace Quik.Framework
{
    public class Startup
    {
         private  readonly IConfiguration _Configuration;
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            _Configuration = configuration;
            env.ConfigureNLog(Path.Combine("configs", "nlog.config"));

            //var builder = new ConfigurationBuilder()
            //    .SetBasePath(env.ContentRootPath)
            //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //    .AddEnvironmentVariables();
            //this.Configuration = builder.Build();
        }



        public void ConfigureContainer(ContainerBuilder builder)
        {

            builder.RegisterModule(new AutofacModule());
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //添加cookie
            services.AddAuthentication(opt =>
            {
                opt.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie();

            services.Configure<IISOptions>(opts =>
            {

            });
            try
            {
                SugarDbConn.DbConnectStr = this._Configuration.GetConnectionString("mysqlConn");   //为数据库连接字符串赋值
            }
            catch (Exception e)
            {

            }
          
         
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime appLifetime)
        {
            //add nlog
            //loggerFactory.AddNLog();
            //app.AddNLogWeb();
            //app.UseCookieAuthentication(new CookieAuthenticationOptions()
            //{
            //    AuthenticationScheme = "MyCookieMiddlewareInstance",
            //    LoginPath = new PathString("/Account/Unauthorized/"),
            //    AccessDeniedPath = new PathString("/Account/Forbidden/"),
            //    AutomaticAuthenticate = true,
            //    AutomaticChallenge = true
            //});

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseAuthentication();

           // app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Index}/{id?}");
            });
        }



    }
}
