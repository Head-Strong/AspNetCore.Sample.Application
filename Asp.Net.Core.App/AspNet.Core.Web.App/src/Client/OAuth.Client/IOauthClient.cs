using System.Collections.Generic;
using models;

namespace OAuth.Client
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

        List<Customer> GetCustomers(string accessToken);
    }
}
