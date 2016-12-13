using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AspNet.Core.Web.App.Bl.Interface;
using AspNet.Core.Web.App.Repo.Interface;
using AspNet.Core.Web.Domains;
using CustomLogger;
using Serilog;

namespace AspNet.Core.Web.App.Bl.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _repository;
        private readonly ILogger _logger;

        public CustomerService(IRepository<Customer> repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            _repository.Data();

            _logger.CustomInformation(user: "Aditya", other: "CustomerService", enviornment: "Dev", host: "localhost", informationMessage: "Inside Get Customer Service");

            //throw new InvalidDataException();

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
