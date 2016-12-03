using System.Linq;
using System.Text;
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
                await AccessTokenProvidedByClientApplication(context, accessToken);
            }
            else
            {
                await UnAuthorizedResponseToClient(context, ErrorMessages.ErrorMessageKey.HeaderMissing, 500);
            }
        }

        
        private async Task AccessTokenProvidedByClientApplication(HttpContext context, string accessToken)
        {
            var cachedToken = _oauthCache.GetAccessToken();

            if (cachedToken.Equals(accessToken))
            {
                _logger.Information("user logged successfully");

                await _next.Invoke(context);
            }
            else
            {
                await AccessTokenAndCachedTokenMisMatch(context, cachedToken, accessToken);                
            }
        }

        private async Task AccessTokenAndCachedTokenMisMatch(HttpContext context, string cachedToken, string accessToken)
        {
            _logger.ForContext("Other", "Cached Token Value is :" + cachedToken + " ~ Access Token :" + accessToken)
                .Information("Mismatch in Access Token And Cached Token");

            _oauthCache.ResetCache();

            var response = _oauthClient.GetUserInfo(accessToken);

            // Invalid Request
            if (response != null)
            {
                _oauthCache.SetAccessToken(accessToken, 50);
                _logger.Information("Handling Authentication Handler Finished.");
                await _next.Invoke(context);
            }
            else
            {
                await UnAuthorizedResponseToClient(context, ErrorMessages.ErrorMessageKey.InvalidAccessToken, 500);                
            }
        }

        private async Task UnAuthorizedResponseToClient(HttpContext context, ErrorMessages.ErrorMessageKey errorMessageKey, int statusCode)
        {
            var errorMessage = ErrorMessages.SgConnectValidationErrorList[errorMessageKey];

            _logger.Information(errorMessage);

            context.Response.StatusCode = statusCode;
            //context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(new Domains.CustomErrorDto()
            {
                ErrorType = (int) errorMessageKey,
                ErrorMessage = errorMessage
            }.ToString());
        }        
    }
}
