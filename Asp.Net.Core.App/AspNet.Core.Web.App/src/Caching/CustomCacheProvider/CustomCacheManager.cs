using System;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;

namespace CustomCacheProvider
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomCacheManager : ICustomCacheManager
    {
        private readonly ICacheManager _cacheManager;

        public CustomCacheManager()
        {
            _cacheManager = CacheFactory.GetCacheManager();
        }

        public void Add<T>(T addObject, string key, int seconds)
        {
            _cacheManager.Add(key, addObject, CacheItemPriority.High, null, new AbsoluteTime(TimeSpan.FromSeconds(seconds)));
        }

        public void Remove(string key)
        {
            _cacheManager.Remove(key);
        }

        public T Get<T>(string key)
        {
            var result = (T)_cacheManager.GetData(key);
            return result;
        }
    }
}
