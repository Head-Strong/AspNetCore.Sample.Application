using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using models;
using Newtonsoft.Json;

namespace OAuth.Client
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

        public List<Customer> GetCustomers(string accessToken)
        {
            List<Customer> customers;

            using (var httpClient = new HttpClient())
            {

                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Add("Content-Type","application/json");
                //httpClient.DefaultRequestHeaders.Add("Authorization", accessToken);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = httpClient.GetAsync("http://localhost:61670/api/customer").Result;

                var dataResult = response.Content.ReadAsStringAsync().Result;

                customers = JsonConvert.DeserializeObject<List<Customer>>(dataResult, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

            }

            return customers;
        }
    }
}