using System.Collections.Generic;
using System.Threading.Tasks;
using AspNet.Core.Web.Domains;

namespace AspNet.Core.Web.App.Bl.Interface
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomers();

        Customer SaveCustomer(Customer customer);

        Task<IEnumerable<Customer>> GetCustomersAsync();

        Task<Customer> SaveCustomerAsync(Customer customer);
    }
}
