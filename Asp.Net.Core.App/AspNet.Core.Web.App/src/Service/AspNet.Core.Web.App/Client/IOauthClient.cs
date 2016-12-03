namespace AspNet.Core.Web.App.Client
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOauthClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        TokenResponse GetAccessToken();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        UserTokenResponse GetUserInfo(string accessToken);
    }
}
