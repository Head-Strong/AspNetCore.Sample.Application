using System;
using System.Web;

namespace MvcApp.Client.AccessTokenCaching
{
    /// <summary>
    /// 
    /// </summary>
    public class OAuthCache : IOauthCache
    {
        private const string AccessTokenCacheKey = "AccessTokenCache";
        private string _cachedAccessToken = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public OAuthCache()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetAccessToken(HttpContextBase context)
        {
            _cachedAccessToken = GetCachedAccessToken(context);

            return _cachedAccessToken ?? (_cachedAccessToken = string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void SetAccessToken(HttpContextBase context, string accessToken, int expiration = 30)
        {
            ResetCache(context);
            context.Cache.Insert(AccessTokenCacheKey, accessToken, null, DateTime.Now.AddSeconds(30), TimeSpan.Zero);
        }

        /// <summary>
        /// 
        /// </summary>
        public void ResetCache(HttpContextBase context)
        {
            _cachedAccessToken = GetCachedAccessToken(context);

            if (!string.IsNullOrWhiteSpace(_cachedAccessToken))
            {
                context.Cache.Remove(AccessTokenCacheKey);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private string GetCachedAccessToken(HttpContextBase context)
        {
            var accessToken = context.Cache.Get(AccessTokenCacheKey);

            return (accessToken == null) ? null : Convert.ToString(accessToken);
        }
    }
}
