using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Quik.Framework.Utils
{
    public class CookieHelper
    {
        public static string UserLoginKey = "Cookie_LoginUser";
        #region 获取Cookie

        /// <summary>
        /// 获得Cookie的值
        /// </summary>
        /// <param name="cookieName"></param>
        /// <returns></returns>
        public static string GetCookieValue(string cookieName)
        {
            return GetCookieValue(cookieName, null);
        }

        /// <summary>
        /// 获得Cookie的值
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetCookieValue(string cookieName, string key)
        {
            HttpRequest request = HttpContext.Current.Request;
            if (request != null)
                return GetCookieValue(request.Cookies[cookieName], key);
            return "";
        }

        /// <summary>
        /// 获得Cookie的子键值
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetCookieValue(HttpCookie cookie, string key)
        {
            if (cookie != null)
            {
                if (!string.IsNullOrEmpty(key) && cookie.HasKeys)
                    return cookie.Values[key];
                else
                    return cookie.Value;
            }
            return "";
        }

        /// <summary>
        /// 获得Cookie
        /// </summary>
        /// <param name="cookieName"></param>
        /// <returns></returns>
        public static HttpCookie GetCookie(string cookieName)
        {
            HttpRequest request = HttpContext.Current.Request;
            if (request != null)
                return request.Cookies[cookieName];
            return null;
        }

        #endregion

        #region 删除Cookie

        /// <summary>
        /// 清除指定Cookie
        /// </summary>
        /// <param name="cookiename">cookiename</param>
        public static void ClearCookie(string cookiename)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookiename];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddYears(-3);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        /// <summary>
        /// 删除Cookie
        /// </summary>
        /// <param name="cookieName"></param>
        public static void RemoveCookie(string cookieName)
        {
            RemoveCookie(cookieName, null);
        }

        /// <summary>
        /// 删除Cookie的子键
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="key"></param>
        public static void RemoveCookie(string cookieName, string key)
        {
            HttpResponse response = HttpContext.Current.Response;
            if (response != null)
            {
                HttpCookie cookie = response.Cookies[cookieName];
                if (cookie != null)
                {
                    if (!string.IsNullOrEmpty(key) && cookie.HasKeys)
                        cookie.Values.Remove(key);
                    else
                        response.Cookies.Remove(cookieName);
                }
            }
        }

        #endregion

        #region 设置/修改Cookie

        /// <summary>
        /// 设置Cookie子键的值
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetCookie(string cookieName, string key, string value)
        {
            SetCookie(cookieName, key, value, null);
        }

        /// <summary>
        /// 设置Cookie值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetCookie(string key, string value)
        {
            SetCookie(key, null, value, null);
        }

        /// <summary>
        /// 设置Cookie值和过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expires"></param>
        public static void SetCookie(string key, string value, DateTime expires)
        {
            SetCookie(key, null, value, expires);
        }

        /// <summary>
        /// 设置Cookie过期时间
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="expires"></param>
        public static void SetCookie(string cookieName, DateTime expires)
        {
            SetCookie(cookieName, null, null, expires);
        }

        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expires"></param>
        public static void SetCookie(string cookieName, string key, string value, DateTime? expires)
        {
            HttpResponse response = HttpContext.Current.Response;
            if (response != null)
            {
                HttpCookie cookie = response.Cookies[cookieName];
                if (cookie != null)
                {
                    if (!string.IsNullOrEmpty(key) && cookie.HasKeys)
                        cookie.Values.Set(key, value);
                    else
                        if (!string.IsNullOrEmpty(value))
                            cookie.Value = value;
                    if (expires != null)
                        cookie.Expires = expires.Value;
                    response.SetCookie(cookie);
                }
            }

        }

        #endregion

        #region 添加Cookie

        /// <summary>
        /// 添加Cookie
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        //public static void AddCookie(string key, string value)
        //{
        //    AddCookie(new HttpCookie(key, value));
        //}

        public static void CreateSecBrowse(string strHouseID)
        {
            string strRecord = CookieHelper.GetCookieValue("HistoreBrowse");
            string[] strItem = strRecord.Split(',');
            for (int i = 0; i < strItem.Length; i++)
            {
                if (strHouseID == strItem[i])
                {
                    return;
                }
            }
            string strTempItem = strHouseID + ",";
            string strBrowseItem = string.Empty;

            HttpCookie record = HttpContext.Current.Request.Cookies["HistoreBrowse"] ?? null;
            if (record == null)
            {
                record = new HttpCookie("HistoreBrowse");
                record.Value = strTempItem;
                strBrowseItem = record.Value;
            }
            else
            {
                record.Value = strTempItem + record.Value;
                strBrowseItem = record.Value;

            }
            string[] strArray = strBrowseItem.Split(',');

            StringBuilder sb = new StringBuilder();

            if (strArray.Length > 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    sb.Append(strArray[i].ToString() + ",");
                }
            }
            else
            {
                for (int i = 0; i < strArray.Length; i++)
                {
                    sb.Append(strArray[i].ToString() + ",");
                }
            }
            string strTempCookies = sb.ToString().Substring(0, sb.ToString().LastIndexOf(","));
            record.Value = strTempCookies;
            record.Expires = DateTime.Now.AddDays(15);
            record.Path = "/";
            HttpContext.Current.Response.Cookies.Add(record);
        }

        /// <summary>
        /// 添加Cookie
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expires"></param>
        public static void AddCookie(string key, string value, DateTime expires)
        {
            HttpResponse response = HttpContext.Current.Response;
            var cookieInfo = response.Cookies[key];
            if (cookieInfo == null)
            {
                HttpCookie cookie = new HttpCookie(key, value);
                cookie.Expires = expires;
                AddCookie(cookie);
            }
            else
            {
                SetCookie(key,value,expires);
            }

        }

        /// <summary>
        /// 添加为Cookie.Values集合
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void AddCookieValues(string cookieName, string key, string value)
        {
            HttpResponse response = HttpContext.Current.Response;
            var cookieInfo = response.Cookies[cookieName];
            if (cookieInfo != null)
            {
                cookieInfo.Values.Add(key, value);
            }
        }

        /// <summary>
        /// 添加为Cookie集合
        /// </summary>
        /// <param name="cookieName">Cookie名称</param>
        /// <param name="expires">过期时间</param>
        public static void AddCookie(string cookieName, DateTime expires)
        {
            var aa = ConfigurationSettings.AppSettings["UserStatusCookieExpires"];
            HttpResponse response = HttpContext.Current.Response;
            var cookieInfo = response.Cookies[cookieName];
            if (cookieInfo == null)
            {
                HttpCookie cookie = new HttpCookie(cookieName);
                cookie.Expires = expires;
                AddCookie(cookie);
            }
            else
            {
               SetCookie(cookieName,expires);
            }

        }

        /// <summary>
        /// cookie不设置过期时间 关闭浏览器cookie就过期
        /// </summary>
        /// <param name="cookieName"></param>
        public static void AddExplorerCookie(string cookieName)
        {
            HttpResponse response = HttpContext.Current.Response;
            var cookieInfo = response.Cookies[cookieName];
            if (cookieInfo == null)
            {
                HttpCookie cookie = new HttpCookie(cookieName);
                AddCookie(cookie);
            }
            else
            {
                SetCookie(cookieName,null);
            }
        }
        /// <summary>
        /// cookie过期时间由config文件配置
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="expires"></param>
        //public static void AddConfigExpiresCookie(string cookieName)
        //{
        //    var configData = ConfigurationSettings.AppSettings["UserStatusCookieExpires"];
        //    int hours = ConvertHelper.ToInt32(configData, 0);
        //    var expires = DateTime.Now.AddHours(hours);
        //    HttpResponse response = HttpContext.Current.Response;
        //    var cookieInfo = response.Cookies[cookieName];
        //    if (cookieInfo == null)
        //    {
        //        HttpCookie cookie = new HttpCookie(cookieName);
        //        cookie.Expires = expires;
        //        AddCookie(cookie);
        //    }
        //    else
        //    {
        //        SetCookie(cookieName, expires);
        //    }

        //}
        /// <summary>
        /// 添加为Cookie.Values集合
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expires"></param>
        public static void AddCookie(string cookieName, string key, string value, DateTime expires)
        {
            HttpResponse response = HttpContext.Current.Response;
            var cookieInfo = response.Cookies[cookieName];
            if (cookieInfo == null)
            {
                HttpCookie cookie=new HttpCookie(cookieName);
                cookie.Expires = expires;
                cookie.Values.Add(key, value);
                AddCookie(cookie);
            }
            else
            {
                SetCookie(cookieName,key,value,expires);
            }

        }

        /// <summary>
        /// 添加Cookie
        /// </summary>
        /// <param name="cookie"></param>
        public static void AddCookie(HttpCookie cookie)
        {
            HttpResponse response = HttpContext.Current.Response;
            if (response != null)
            {
                //指定客户端脚本是否可以访问[默认为false]
                cookie.HttpOnly = true;
                //指定统一的Path，比便能通存通取
                cookie.Path = "/";
                //设置跨域,这样在其它二级域名下就都可以访问到了
                //cookie.Domain = "nas.com";
                response.AppendCookie(cookie);
            }
        }

        #endregion
    }
}