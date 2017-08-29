using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quik.Framework.AppService.Sys;
using Quik.Framework.Dto;
using Quik.Framework.Entity;
using Quik.Framework.Enum;
using Quik.Framework.Filters;
using Quik.Framework.Models;
using Quik.Framework.Utils;

namespace Quik.Framework.Controllers.System
{
    public class SysRoleController : BaseController
    {
        private readonly SysRoleAppService _roleApp;

        public SysRoleController(SysRoleAppService roleApp)
        {
            _roleApp = roleApp;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form(string id)
        {
            ViewBag.Id = id;
            return View();
        }
        public JsonResult GetData(DataGridEx param)
        {
            var data = new DataGridEx();
            try
            {
                data = _roleApp.GetRoleList(param);
            }
            catch (Exception ex)
            {
                LogNHelper.Exception(ex);
            }
            return JsonEx(data);
        }

        public JsonResult SaveData(sys_role dto)
        {
            _roleApp.SaveRoleData(dto);

            return JsonJui();
        }
        public ActionResult GetDataById(string id)
        {
            var result=new ResultJson();
            result.Data = _roleApp.GetRoleById(id);
            result.statusCode=JuiJsonEnum.Ok;
            return Content(result.ToJson());
        }
	}
}