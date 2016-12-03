namespace AspNet.Core.Web.App.Client
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
        string GetAccessToken();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        void SetAccessToken(string accessToken, int expiration = 30);

        /// <summary>
        /// 
        /// </summary>
        void ResetCache();
    }
}