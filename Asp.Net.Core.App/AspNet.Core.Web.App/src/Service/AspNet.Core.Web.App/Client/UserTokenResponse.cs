using Newtonsoft.Json;

namespace AspNet.Core.Web.App.Client
{
    /// <summary>
    /// 
    /// </summary>
    public class UserTokenResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "sub")]
        public string Sub { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}