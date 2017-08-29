using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quik.Framework.Dto;
using Quik.Framework.Entity;
using Quik.Framework.Enum;
using Quik.Framework.Filters;
using Quik.Framework.Models;
using Quik.Framework.Sys;
using Quik.Framework.Utils;

namespace Quik.Framework.Controllers.System
{
    public class SysFuncController : BaseController
    {

        private readonly SysFuncAppService _funcApp;

        public SysFuncController(SysFuncAppService funcApp)
        {
            _funcApp = funcApp;
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
                data = _funcApp.GetFuncList(param);
            }
            catch (Exception ex)
            {
                LogNHelper.Exception(ex);
            }
            return JsonEx(data);
        }

        public JsonResult SaveData(sys_func dto)
        {
            _funcApp.SaveData(dto);

            return JsonJui();
        }

        public ActionResult GetDataById(long id)
        {
            var data = _funcApp.GetFuncById(id);
            var result = new ResultJson();
            result.Data = data;
            result.statusCode = JuiJsonEnum.Ok;
            return Content(result.ToJson());
        }
	}
}