﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quik.Framework.Models;
using Quik.Framework.Utils;

namespace Quik.Framework.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // LogNHelper.Info("访问了首页");
            var ucookie = UserCookieHelper.CookieParse(this.HttpContext.User);
            ViewBag.AccountName = ucookie.AccountName;
            ViewBag.RealName = ucookie.RealName;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
