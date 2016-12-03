using System;
using Microsoft.Extensions.Caching.Memory;

namespace AspNet.Core.Web.App.Client
{
    /// <summary>
    /// 
    /// </summary>
    public class OAuthCache : IOauthCache
    {
        private readonly IMemoryCache _memoryCache;
        private const string AccessTokenCacheKey = "AccessTokenCache";
        private string _cachedAccessToken = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public OAuthCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetAccessToken()
        {
            GetCachedAccessToken(out _cachedAccessToken);

            return _cachedAccessToken ?? (_cachedAccessToken = string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void SetAccessToken(string accessToken, int expiration = 30)
        {
            ResetCache();

            _memoryCache.Set(AccessTokenCacheKey, accessToken, new MemoryCacheEntryOptions()
                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(expiration)));


        }

        /// <summary>
        /// 
        /// </summary>
        public void ResetCache()
        {
            if (GetCachedAccessToken(out _cachedAccessToken))
            {
                _memoryCache.Remove(AccessTokenCacheKey);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="returnCachedAccessToken"></param>
        /// <returns></returns>
        private bool GetCachedAccessToken(out string returnCachedAccessToken)
        {
            return _memoryCache.TryGetValue(AccessTokenCacheKey, out returnCachedAccessToken);
        }
    }
}
