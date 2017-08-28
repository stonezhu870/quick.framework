using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using RealFarm.Enum;
using RealFarm.Utils;
using RealFarmSystem.Models;

namespace RealFarmSystem.Filters
{
    public class BaseController : Controller
    {

        /// <summary>
        /// 未处理异常处理
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnException(ExceptionContext filterContext)
        {

            //if (!filterContext.ExceptionHandled && filterContext.Exception is ArgumentOutOfRangeException)
            if (!filterContext.ExceptionHandled)
            {
                //filterContext.Result = new RedirectResult("~/Error.htm");

                LogNHelper.Exception(filterContext.Exception);
                filterContext.ExceptionHandled = true;

                filterContext.Result = Error("系统错误");
            }

            //base.OnException(filterContext);
        }

        #region json时间格式转化

        /// <summary>
        /// 通过json.net序列化
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dateTimeFormatStr"></param>
        /// <param name="isAllowGet">是否允许get</param>
        /// <returns></returns>
        protected virtual JsonResult JsonEx(object data, string dateTimeFormatStr = "yyyy-MM-dd HH:mm:ss", bool isAllowGet = true)
        {
            return new JsonResultDateTimeFormat()
            {
                Data = data,
                JsonRequestBehavior = isAllowGet == true ? JsonRequestBehavior.AllowGet : JsonRequestBehavior.DenyGet,
                DateTimeFormateStr = dateTimeFormatStr,
                ContentEncoding = Encoding.UTF8,
                ContentType = "text/plain",
            };
        }
        /// <summary>
        /// 获取客户端ip
        /// </summary>
        /// <returns></returns>
        [NonAction]
        protected string GetClientIp()
        {
            string str = this.HttpContext.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(str))
                str = this.HttpContext.Request.ServerVariables["REMOTE_ADDR"];
            if (string.IsNullOrEmpty(str))
                str = this.HttpContext.Request.UserHostAddress;
            return str;
        }

      #endregion
        #region bjui框架的ajax返回结果

        protected virtual JsonResult JsonJui()
        {
            var result = new JuiJsonResult() { statusCode = JuiJsonEnum.Ok };
            return Json(result);
        }
        protected virtual JsonResult JsonJui(JuiJsonEnum juiJsonEnum)
        {
            var result = new JuiJsonResult() { statusCode = juiJsonEnum };
            return Json(result);
        }
        protected virtual ContentResult Success()
        {
            var result =new JuiJsonResult(){statusCode = JuiJsonEnum.Ok};
            return Content(result.ToJson());
        }
        protected virtual ContentResult Error()
        {
            var result = new JuiJsonResult() { statusCode = JuiJsonEnum.Error, message = "操作失败" };
            return Content(result.ToJson());
        }
        protected virtual ContentResult Error(string msg)
        {
            var result = new JuiJsonResult() { statusCode = JuiJsonEnum.Error, message = msg };
            return Content(result.ToJson());
        }
        protected virtual ContentResult TimeOut()
        {
            var result = new JuiJsonResult() { statusCode = JuiJsonEnum.TimeOut };
            return Content(result.ToJson());
        }
        protected virtual JsonResult Success(string msg)
        {
            var result = new JuiJsonResult() { statusCode = JuiJsonEnum.Ok, message = msg };
            return Json(result,JsonRequestBehavior.AllowGet);
        }
           #endregion
    }
}