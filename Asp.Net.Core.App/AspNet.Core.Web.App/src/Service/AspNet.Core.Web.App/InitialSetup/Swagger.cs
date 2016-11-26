using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.Swagger.Model;

namespace AspNet.Core.Web.App.InitialSetup
{
    /// <summary>
    /// 
    /// </summary>
    internal static class Swagger
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        internal static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "My API",
                    Description = "My First ASP.NET Core Web API",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "Talking Dotnet", Email = "contact@talkingdotnet.com", Url = "www.talkingdotnet.com" }
                });

                options.IncludeXmlComments(GetXmlCommentsPath());
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static string GetXmlCommentsPath()
        {
            var app = PlatformServices.Default.Application;
            return System.IO.Path.Combine(app.ApplicationBasePath, "AspNet.Core.Web.App.xml");
        }
    }
}
