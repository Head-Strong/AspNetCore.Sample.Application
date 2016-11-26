using System.Collections.Generic;
using System.Threading.Tasks;
using AspNet.Core.Web.App.Bl.Interface;
using AspNet.Core.Web.App.Repo.Interface;
using AspNet.Core.Web.Domains;

namespace AspNet.Core.Web.App.Bl.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _repository;

        public CustomerService(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _repository.GetEntities();
        }

        public Customer SaveCustomer(Customer customer)
        {
            return _repository.Save(customer);
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _repository.GetEntitiesAsync();
        }

        public async Task<Customer> SaveCustomerAsync(Customer customer)
        {
            return await _repository.SaveAsync(customer);
        }
    }
}
