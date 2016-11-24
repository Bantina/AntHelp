using System;
using System.Collections;
using System.Web;
using System.Web.Caching;

namespace QX_Frame.Helper_DG_Framework_4_6
{
    /*2016-11-12 22:58:25 author:qixiao*/
    public abstract class Cache_Helper_DG
    {
        /// <summary>
        /// Cache_Get
        /// </summary>
        /// <param name="cacheKey">cacheKey</param>
        /// <returns></returns>
        public static object Cache_Get(string cacheKey)
        {
            return ProcessFlow_Helper_DG.channel_Exception_Log(() => HttpRuntime.Cache[cacheKey], "Cache_Helper_DG Cache_Get");
        }

        /// <summary>
        /// Cache_Add
        /// </summary>
        /// <param name="cacheKey">key</param>
        /// <param name="cacheValue">object value</param>
        /// <param name="dependencies">缓存的依赖项，也就是此项的更改意味着缓存内容已经过期。如果没有依赖项，可将此值设置为NULL。</param>
        /// <param name="absoluteExpiration">如果设置slidingExpiration，则该项必须设置为DateTime.MaxValue。是日期型数据，表示缓存过期的时间，.NET 2.0提供的缓存在过期后是可以使用的，能使用多长时间，就看这个参数的设置。</param>
        /// <param name="slidingExpiration">如果设置absoluteExpiration，则该项必须设置为TimeSpan.Zero。表示一段时间间隔，表示缓存参数将在多长时间以后被删除，此参数与absoluteExpiration参数相关联。</param>
        /// <param name="cacheItemPriority">表示撤销缓存的优先值，此参数的值取自枚举变量“CacheItemPriority”，优先级低的数据项将先被删除。此参数主要用在缓存退出对象时。</param>
        /// <param name="cacheItemRemovedCallback">表示缓存删除数据对象时调用的事件，一般用做通知程序。</param>
        public static Boolean Cache_Add(string cacheKey, object cacheValue, CacheDependency dependencies = null, DateTime absoluteExpiration = default(DateTime), TimeSpan slidingExpiration = default(TimeSpan), CacheItemPriority cacheItemPriority = CacheItemPriority.NotRemovable, CacheItemRemovedCallback cacheItemRemovedCallback = null)
        {
            return ProcessFlow_Helper_DG.channel_Exception_Log(
                () =>
                {
                    DateTime absoluteExpirationTime = default(DateTime);
                    if (!DateTime.TryParse(absoluteExpiration.ToString(), out absoluteExpirationTime) || absoluteExpiration.Equals(default(DateTime)))
                        absoluteExpirationTime = DateTime.MaxValue;
                    else
                        slidingExpiration = TimeSpan.Zero;

                    TimeSpan slidingExpirationTime = default(TimeSpan);
                    if (!TimeSpan.TryParse(slidingExpiration.ToString(), out slidingExpirationTime) || slidingExpiration.Equals(default(TimeSpan)))
                        slidingExpirationTime = TimeSpan.Zero;

                    HttpRuntime.Cache.Insert(cacheKey, cacheValue, dependencies, absoluteExpirationTime, slidingExpirationTime, cacheItemPriority, cacheItemRemovedCallback);
                    return true;
                }, "Cache_Helper_DG Cache_Add");
        }
        /// <summary>
        /// Cache_Delete
        /// </summary>
        /// <param name="cacheKey">cacheKey</param>
        public static Boolean Cache_Delete(string cacheKey)
        {
            return ProcessFlow_Helper_DG.channel_Exception_Log(
                () =>
                {
                    HttpRuntime.Cache.Remove(cacheKey);
                    return true;
                }, "Cache_Helper_DG Cache_Delete");
        }

        /// <summary>
        /// Cache_DeleteAll
        /// </summary>
        public static Boolean Cache_DeleteAll()
        {
            return ProcessFlow_Helper_DG.channel_Exception_Log(
                () =>
                {
                    Cache _cache = HttpRuntime.Cache;
                    IDictionaryEnumerator CacheEnum = _cache.GetEnumerator();
                    while (CacheEnum.MoveNext())
                    {
                        _cache.Remove(CacheEnum.Key.ToString());
                    }
                    return true;
                }, "Cache_Helper_DG Cache_DeleteAll");
        }
    }
}
