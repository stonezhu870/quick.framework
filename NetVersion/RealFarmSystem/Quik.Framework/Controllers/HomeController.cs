using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quik.Framework.AppService;
using Quik.Framework.Filters;
using Quik.Framework.Models;
using Quik.Framework.Utils;


namespace Quik.Framework.Controllers
{
    public class HomeController : BaseController
    {
        private readonly SysMenuAppService _menuApp;

        public HomeController(SysMenuAppService  menuApp)
        {
            _menuApp = menuApp;
        }
        public ActionResult Index()
        {
            var menu = _menuApp.GetTopMenuList();
            ViewBag.TopMenuList = menu;
            return View();
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Grid()
        {
            return View();
        }

        public ActionResult GetRoleMenu()
        {
            var result=new ResultJson();
            try
            {
                result.Data = _menuApp.GetRoleMenu();
                result.Status = true;
            }
            catch (Exception ex)
            {
                LogNHelper.Exception(ex);
            }

            return Content(result.ToJson());
        }
	}
}