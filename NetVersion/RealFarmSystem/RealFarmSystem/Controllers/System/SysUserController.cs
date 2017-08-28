using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealFarm.AppService;
using RealFarm.Dto;
using RealFarm.Entity;
using RealFarm.Enum;
using RealFarm.Utils;
using RealFarmSystem.Filters;
using RealFarmSystem.Models;

namespace RealFarmSystem.Controllers.System
{
    public class SysUserController : BaseController
    {
        private SysUserAppService _userApp;

        public SysUserController(SysUserAppService userApp)
        {
            _userApp = userApp;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetData(DataGridEx param)
        {
            var data = new DataGridEx();

            try
            {


                data = _userApp.GetUserList(param);
                //LogNHelper.Info("测试grid");
            }
            catch (Exception ex)
            {
                LogNHelper.Exception(ex);
            }

            return JsonEx(data);
        }
        public ActionResult Form(string id)
        {
            ViewBag.Id = id;
            return View();
        }

        public JsonResult SaveData(sys_user dto)
        {
            _userApp.SaveData(dto);

            return JsonJui();
        }

        public ActionResult GetDataById(string id)
        {
            var data = _userApp.GetDataById(id);
            var result = new ResultJson();
            result.Data = data;
            result.statusCode=JuiJsonEnum.Ok;
            return Content(result.ToJson());
        }
	}
}