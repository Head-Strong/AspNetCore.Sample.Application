using System.Web;

namespace MvcApp.Client.AccessTokenCaching
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOauthCache
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string GetAccessToken(HttpContextBase context);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        void SetAccessToken(HttpContextBase context, string accessToken, int expiration = 30);

        /// <summary>
        /// 
        /// </summary>
        void ResetCache(HttpContextBase context);
    }
}