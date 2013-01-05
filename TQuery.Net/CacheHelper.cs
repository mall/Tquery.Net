using System;
using System.Runtime.Caching;

namespace TQuery.Net
{
    public class CacheHelper
    {
        /// <summary>
        /// 3600 * 24
        /// </summary>
        private static long _maxSeconds = 3600 * 24;
        /// <summary>
        /// 获取指定的缓存
        /// </summary>
        /// <param name="key">Cache的名称</param>
        /// <returns></returns>
        public static object Get(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return null;
            }
            MemoryCache cache = MemoryCache.Default;
            return cache.Get(key);

        }

        /// <summary>
        /// 返回指定的缓存,如果不存在就用函数返回的值,自动加入缓存.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="fun"></param>
        /// <returns></returns>
        public static T Get<T>(string key, Func<T> fun, long seconds = 1800)
        {
            T t;
            object o = Get(key);
            if (o != null && o is T)
            {
                t = (T)o;
            }
            else
            {
                t = fun();
                Set(key, t, seconds);
            }
            return t;
        }

        /// <summary>
        /// 删除指定的缓存
        /// </summary>
        /// <param name="key">Cache的名称</param>
        public static void Remove(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return;
            }
            MemoryCache cache = MemoryCache.Default;
            cache.Remove(key);
        }

        /// <summary>
        /// 设置Cache的值,过期时间:到时间绝对过期. 时间秒.
        /// </summary>
        /// <param name="key">Cache的名称</param>
        /// <param name="value">Cache的值</param>
        /// <param name="seconds">过期时间,相对当前时间: 秒. 默认:1800</param>        
        public static void Set(string key, object value, long seconds = 1800)
        {
            if (value == null || string.IsNullOrEmpty(key))
            {
                return;
            }
            MemoryCache cache = MemoryCache.Default;
            if (seconds < 1)
            {
                seconds = _maxSeconds;
            }
            cache.Set(key, value, DateTimeOffset.UtcNow.AddSeconds(seconds));
        }
    }

}
