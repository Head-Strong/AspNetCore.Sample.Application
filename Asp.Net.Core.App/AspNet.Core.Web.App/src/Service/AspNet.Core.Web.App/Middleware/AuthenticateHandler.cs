using System;
using System.Linq;
using System.Threading.Tasks;
using AspNet.Core.Web.App.Client;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace AspNet.Core.Web.App.Middleware
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthenticateHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly IOauthClient _oauthClient;
        private readonly IOauthCache _oauthCache;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        /// <param name="oauthClient"></param>
        /// <param name="oauthCache"></param>
        public AuthenticateHandler(RequestDelegate next, ILogger logger, IOauthClient oauthClient, IOauthCache oauthCache)
        {
            _next = next;
            _logger = logger;
            _oauthClient = oauthClient;
            _oauthCache = oauthCache;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            _logger.Information("Handling Authentication Handler : " + context.Request.Path);

            var accessToken = context.Request.Headers["Authorization"].FirstOrDefault();

            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                var cachedToken = _oauthCache.GetAccessToken();

                if (!cachedToken.Equals(accessToken))
                {
                    _logger.ForContext("Other", "Cached Token Value is :" + cachedToken + " ~ Tomcat Token :" + accessToken)
                        .Information("Mismatch in Authorization Header");

                    _oauthCache.ResetCache();

                    var response = _oauthClient.GetUserInfo(accessToken);

                    // Invalid Request
                    if (response == null)
                    {
                        _logger.Information("Invalid AccessToken provided by user :" + accessToken);
                        await context.Response.WriteAsync("Invalid Access Token Guys");
                    }
                    else
                    {
                        _oauthCache.SetAccessToken(accessToken,50);
                        _logger.Information("Handling Authentication Handler Finished.");
                        await _next.Invoke(context);
                        
                    }
                }
                else
                {
                    _logger.Information("user logged successfully");
                    await _next.Invoke(context);
                }
            }
            else
            {
                _logger.Information("Authorization Header is missing");
                await context.Response.WriteAsync("Invalid header");
            }
        }
    }
}
