using AspNet.Core.Web.App.Bl.Implementation;
using AspNet.Core.Web.App.Bl.Interface;
using AspNet.Core.Web.App.Repo.Implementation;
using AspNet.Core.Web.App.Repo.Interface;
using AspNet.Core.Web.Domains;
using Microsoft.Extensions.DependencyInjection;

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
        }
    }
}
