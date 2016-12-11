using AspNet.Core.Web.App.Bl.Implementation;
using AspNet.Core.Web.App.Bl.Interface;
using AspNet.Core.Web.App.Client;
using AspNet.Core.Web.App.Repo.Implementation;
using AspNet.Core.Web.App.Repo.Interface;
using AspNet.Core.Web.Domains;
using CustomCacheProvider;
using EntityFramework.Core;
using Microsoft.Extensions.DependencyInjection;
using Orm.Service.Interface;

namespace AspNet.Core.Web.App.InitialSetup
{
    /// <summary>
    /// 
    /// </summary>
    internal static class Dependency
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        internal static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Customer>, CustomerRepository>();
            services.AddScoped<IRepository<Address>, AddressRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOrmservice, TestDatabaseContext>();
            services.AddScoped<IOauthClient, OauthClient>();
            services.AddScoped<IOauthCache, OAuthCache>();
            services.AddScoped<ICustomCacheManager, CustomCacheManager>();
        }
    }
}
