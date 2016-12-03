using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Serilog;

namespace AspNet.Core.Web.App.Middleware
{
    /// <summary>
    /// 
    /// </summary>
    public class ErrorHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public ErrorHandler(RequestDelegate next, Serilog.ILogger logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public void Invoke(HttpContext context)
        {
            _logger.Information("Handling ErrorHandlerMiddleware : " + context.Request.Path);
            _logger.Information("Handling TestMiddleware Finished.");
        }
    }
}
