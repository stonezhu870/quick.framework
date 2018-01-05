using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quik.Framework.Entity;

namespace Quick.Framework.Layui.Controllers.SysManage
{
    public class SysMenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            var list=new List<sys_menu>();

            var model=new sys_menu();
            model.id = 1;
            model.menu_name = "菜单管理";
            model.menu_url = "/SysMenu/Index";
            model.menu_icon = "fa-file";
            model.create_time=DateTime.Now;
            model.menu_sort = 1;
            model.creator = "amdin";
            list.Add(model);
            var newObj = new
            {
                code = 0,
                msg = "",
                count = 45,
                data = list
            };
            return Json(newObj);
        }

        public ActionResult Form()
        {
            return View();
        }
    }
}