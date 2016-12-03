using System.Web.Mvc;
using MvcApp.Client.AccessTokenCaching;
using OAuth.Client;

namespace MvcApp.Client.Filters
{
    public class CustomAuthenticationAttribute : ActionFilterAttribute
    {
        private readonly IOauthClient _ouathClient;
        private readonly IOauthCache _ouathCache;

        public CustomAuthenticationAttribute()
        {
            _ouathClient = new OauthClient();
            _ouathCache = new OAuthCache();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var cachedAccessToken = _ouathCache.GetAccessToken(filterContext.HttpContext);

            if (string.IsNullOrWhiteSpace(cachedAccessToken))
            {
                var tokenEndpointResponse = _ouathClient.GetAccessToken();

                if (string.IsNullOrWhiteSpace(tokenEndpointResponse.Error))
                {
                    _ouathCache.SetAccessToken(filterContext.HttpContext, tokenEndpointResponse.AccessToken, 50);
                    SetAccessTokenInRouteData(filterContext,tokenEndpointResponse.AccessToken);
                }
                else
                {
                    // Drop an Email. Not able to connect to Oauth Server.
                    // Log into database.
                }
            }
            else
            {
                SetAccessTokenInRouteData(filterContext, cachedAccessToken);
            }            
        }

        private static void SetAccessTokenInRouteData(ControllerContext filterContext, string accessToken)
        {
            filterContext.RouteData.Values.Add("AccessToken", accessToken);
        }
    }
}