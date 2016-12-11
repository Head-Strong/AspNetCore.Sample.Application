using System.Threading.Tasks;
using AspNet.Core.Web.App.InitialSetup;
using AspNet.Core.Web.App.Middleware;
using EntityFramework.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using CustomLogger;

namespace AspNet.Core.Web.App
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="env"></param>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddMemoryCache();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                });
            });

            services.ConfigureDependencies();

            services.ConfigureSwagger();

            var connection = @"Server=(localdb)\ProjectsV13;Database=TestDatabase;Trusted_Connection=True;";

            services
                .AddDbContext<TestDatabaseContext>(options => options.UseSqlServer(connection));

            services.ConfigureSeriLog(Configuration);

            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        ///
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();

            app.UseExceptionHandler(configure: CustomHandler);

            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUi();

            loggerFactory.AddSerilog();

            app.UseCors("AllowAllOrigins");

            app.UseMiddleware<AuthenticateHandler>();

            //app.UseMiddleware<TestMiddleware>();

            app.UseMvc();            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        private static void CustomHandler(IApplicationBuilder app)
        {
            // app.Run(handler: CustomHandler);

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test Successful");
            });
        }
    }
}
