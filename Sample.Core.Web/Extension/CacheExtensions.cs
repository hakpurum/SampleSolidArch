using Sample.Core.Web.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Caching;

namespace Sample.Core.Web.Extension
{
    /// <summary>
    /// Class CacheExtensions.
    /// </summary>
    public static class CacheExtensions
    {
        static readonly object sync = new object();

        /// <summary>
        /// Verileri Cacheler gönderilen data cache de yoksa cache e atar varsa geriye cache den döner
        /// Kullanımı : List<User> items = Cache.Data("test", 10, () => GetUsers());
        /// </summary>
        /// <typeparam name="T">GenericType</typeparam>
        /// <param name="cache"></param>
        /// <param name="cacheKey">Cache Adı</param>
        /// <param name="cacheTimeType"></param>
        /// <param name="expiration"></param>
        /// <param name="method"></param>
        /// <param name="expirationSeconds">Cache in bitme süresi gün bazında</param>
        /// <returns></returns>
        public static T Data<T>(this Cache cache, string cacheKey, CacheTimeType cacheTimeType, int expiration, Func<T> method)
        {
            var data = cache == null ? default(T) : (T)cache[cacheKey];
            //if (data == null)
            //{
            data = method();

            if (expiration > 0 && data != null)
            {
                lock (sync)
                {
                    DateTime expirationTime;

                    #region CacheTimeType
                    switch (cacheTimeType)
                    {
                        case CacheTimeType.Millisecond:
                            expirationTime = DateTime.Now.AddMilliseconds(expiration);
                            break;
                        case CacheTimeType.Second:
                            expirationTime = DateTime.Now.AddSeconds(expiration);
                            break;
                        case CacheTimeType.Minute:
                            expirationTime = DateTime.Now.AddMinutes(expiration);
                            break;
                        case CacheTimeType.Day:
                            expirationTime = DateTime.Now.AddDays(expiration);
                            break;
                        case CacheTimeType.Hour:
                            expirationTime = DateTime.Now.AddHours(expiration);
                            break;
                        case CacheTimeType.Month:
                            expirationTime = DateTime.Now.AddMonths(expiration);
                            break;
                        case CacheTimeType.Year:
                            expirationTime = DateTime.Now.AddYears(expiration);
                            break;
                        default:
                            expirationTime = DateTime.Now.AddSeconds(expiration);
                            break;
                    }
                    #endregion

                    if (cache != null) cache.Insert(cacheKey, data, null, expirationTime, Cache.NoSlidingExpiration);
                }
            }
            //}
            return data;
        }

        public static T Get<T>(this Cache cache, string cacheKey)
        {
            var data = cache == null ? default(T) : (T)cache[cacheKey];
            return data;
        }
    }
}
