using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace AspNet.Core.Web.App.Client
{
    /// <summary>
    /// 
    /// </summary>
    public class OauthClient : IOauthClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TokenResponse GetAccessToken()
        {
            TokenResponse tokenResponse = null;

            var postData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("client_id", "oauth2_api"),
                new KeyValuePair<string, string>("client_secret", "oauth2apiservicessecret"),
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("scope", "openid profile roles email"),
                new KeyValuePair<string, string>("username", "adi"),
                new KeyValuePair<string, string>("password", "read")
            };

            //var contentValues = new FormUrlEncodedContent(postData);

            using (var httpClient = new HttpClient())
            {
                using (var content = new FormUrlEncodedContent(postData))
                {
                    content.Headers.Clear();
                    content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                    var response = httpClient.PostAsync("http://localhost:2020/connect/token", content).Result;

                    var dataResult = response.Content.ReadAsStringAsync().Result;

                    tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(dataResult, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });
                }
            }

            return tokenResponse;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public UserTokenResponse GetUserInfo(string accessToken)
        {
            UserTokenResponse userTokenResponse;

            using (var httpClient = new HttpClient())
            {

                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                var response = httpClient.GetAsync("http://localhost:2020/connect/userinfo").Result;

                var dataResult = response.Content.ReadAsStringAsync().Result;

                userTokenResponse = JsonConvert.DeserializeObject<UserTokenResponse>(dataResult, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

            }

            return userTokenResponse;
        }
    }
}