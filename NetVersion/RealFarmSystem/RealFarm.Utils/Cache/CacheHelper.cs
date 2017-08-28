using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace RealFarm.Utils
{
    public class CacheHelper
    {
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="expires_in">过期时间秒数</param>
        public static void AddCacheObj(string key, object value, int expires_in)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Add(key, value, null, DateTime.Now.AddDays(expires_in), TimeSpan.Zero,
                   CacheItemPriority.Normal, null);
            //Cache.Add("ApiToken", accessToken, null, DateTime.Now.AddSeconds(expires_in), TimeSpan.Zero,
            //    CacheItemPriority.Normal);
        }

        /// <summary>
        /// 获取缓存数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetCacheObj(string key)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            return objCache[key];
        }

        /// <summary>
        /// 清楚单个缓存
        /// </summary>
        /// <param name="key"></param>
        public static void ClearCacheObj(string key)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Remove(key);
        }

        /// <summary>
        /// 清除所有缓存
        /// </summary>
        public static void Clear()
        {
            //要循环访问 Cache 对象的枚举数
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            IDictionaryEnumerator enumerator = objCache.GetEnumerator();//检索用于循环访问包含在缓存中的键设置及其值的字典枚举数
            if (enumerator != null)
            {
                while (enumerator.MoveNext())
                {
                    objCache.Remove(enumerator.Key.ToString());
                }
            }
        }
    }
}