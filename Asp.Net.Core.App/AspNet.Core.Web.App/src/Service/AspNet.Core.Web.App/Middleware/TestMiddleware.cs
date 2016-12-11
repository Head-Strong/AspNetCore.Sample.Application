using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Serilog;
using CustomLogger;

namespace AspNet.Core.Web.App.Middleware
{
    /// <summary>
    /// 
    /// </summary>
    public class TestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public TestMiddleware(RequestDelegate next, Serilog.ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            _logger.CustomInformation(informationMessage:"Handling TestMiddleware : " + context.Request.Path);
            await _next.Invoke(context);
            _logger.CustomInformation(informationMessage:"Handling TestMiddleware Finished.");
        }
    }
}
