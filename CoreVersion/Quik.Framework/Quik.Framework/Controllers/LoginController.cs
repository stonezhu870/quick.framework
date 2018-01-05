using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quik.Framework.Models;
using Quik.Framework.Dto;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json;
using System.Security.Principal;
using Quik.Framework.AppService.System;

namespace Quik.Framework.Controllers
{
    public class LoginController : Controller
    {

        private readonly SysRoleAppService _roleApp;

        public LoginController(SysRoleAppService roleApp)
        {
            _roleApp = roleApp;
        }
        public IActionResult Index()
        {
            var ucookie =UserCookieHelper.CookieParse(this.HttpContext.User);
            if (ucookie!=null)
            {
                return Redirect("/home/index");
            }


            var roleApp = new SysRoleAppService();
            ViewBag.Count= roleApp.GetUserCunt();
            return View();
        }


        public JsonResult LoginOn(string logname, string logpass)
        {
            var result = new ResultJson();
            try
            {
                //var user = _userApp.LoginValidate(logname.Trim(), logpass.Trim());
                //if (user != null)
                //{
                //    var loginUserDto = new LoginUserDto();
                //    loginUserDto.Id = user.Id;
                //    loginUserDto.AccountName = user.AccountName;
                //    loginUserDto.RealName = user.RealName;
                //    loginUserDto.IsSuper = user.IsSuper;
                //    loginUserDto.SysRoleId = user.SysRoleId;

                //    //设置cookie
                //    // FormsAuthentication.SetAuthCookie(loginUserDto.AccountName, false);
                //    LoginCookieHepler.AddCurrentUser(loginUserDto);
                //    result.Status = true;

                //}

                var user = new LoginUserDto();
                user.Id = 787878;
                user.AccountName = "yushuo";
                user.RealName = "哈哈";
                user.SysRoleId = 1;
                WriteCookie(user);

                result.Status = true;


            }
            catch (Exception ex)
            {
                //LogNHelper.Exception(ex);
            }
            return Json(result);
        }
        public ActionResult LogOff()
        {
            //FormsAuthentication.SignOut();
            //注销登录
            this.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }

        private  void WriteCookie(LoginUserDto dto)
        {

            List<Claim> claims = new List<Claim>();
            string cliamsStr = JsonConvert.SerializeObject(dto);
            claims.Add(new Claim("quickUser", cliamsStr));
            var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
            this.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, new AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddHours(10),
                IsPersistent = false,
                AllowRefresh = false
            });
        }


        private LoginUserDto GetCookieData()
        {
           var cookie= HttpContext.User.Claims.FirstOrDefault(x => x.Type == "quickUser");
            if (cookie != null&&cookie.Value!=null)
            {
                var ucookie = JsonConvert.DeserializeObject<LoginUserDto>(cookie.Value);
                return ucookie;
            }

            return null;
        }


        public JsonResult GetUserCount()
        {
            var result=new ResultJson();
            try
            {
              
                result.Data= _roleApp.GetUserCunt();
                result.Status = true;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }

            return Json(result);
        }
    }
}