using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quik.Framework.AppService;
using Quik.Framework.Dto;
using Quik.Framework.Entity;
using Quik.Framework.Enum;
using Quik.Framework.Filters;
using Quik.Framework.Models;
using Quik.Framework.Utils;

namespace Quik.Framework.Controllers.System
{
    public class SysMenuController : BaseController
    {
        private SysMenuAppService _menuApp;

        public SysMenuController(SysMenuAppService menuApp)
        {
            _menuApp = menuApp;
        }
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Form(string id)
        {
            ViewBag.Id = id;
            var menuList = _menuApp.GetMenuList();
            menuList.Insert(0,new sys_menu(){id = "",menu_name = "请选择"});
            ViewBag.MenuSel = new SelectList(menuList, "id", "menu_name");

            return View();
        }

        public JsonResult GetData()
        {
            var data = new DataGridEx();
            try
            {
                data.list = _menuApp.GetMenuList();
            }
            catch (Exception ex)
            {
                LogNHelper.Exception(ex);
            }
            return JsonEx(data);
        }
        public JsonResult SaveData(sys_menu dto)
        {
            if (string.IsNullOrEmpty(dto.id))
            {
                _menuApp.AddMenu(dto);
            }
            else
            {
                _menuApp.UpdateMenu(dto);
            }
            return Success("保存成功");
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveError(sys_menu dto)
        {
            return Error();
        }


        public ActionResult GetDataById(string id)
        {
            var result=new ResultJson();
            result.Data = _menuApp.GetMenuById(id);
            result.statusCode = JuiJsonEnum.Ok;

            return Content(result.ToJson());
        }
	}
}