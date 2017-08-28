using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using RealFarm.Utils;

namespace RealFarmSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //依赖注入
            try
            {
                AutofacConfig.ConfigureContainer();

            }
            catch (Exception ex)
            {
                LogNHelper.Exception("IOC依赖注入失败" + ex.Message);
            }
        }
    }
}
