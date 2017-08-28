using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealFarm.AppService.Sys;
using RealFarm.Dto;
using RealFarm.Entity;
using RealFarm.Enum;
using RealFarm.Utils;
using RealFarmSystem.Filters;
using RealFarmSystem.Models;

namespace RealFarmSystem.Controllers.System
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