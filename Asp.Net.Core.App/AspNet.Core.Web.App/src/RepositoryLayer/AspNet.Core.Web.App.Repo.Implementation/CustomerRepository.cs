using System.Collections.Generic;
using System.Threading.Tasks;
using AspNet.Core.Web.App.Repo.Implementation.Mapper;
using AspNet.Core.Web.App.Repo.Interface;
using AspNet.Core.Web.Domains;
using EntityFramework.Core;
using Microsoft.EntityFrameworkCore;
using Orm.Service.Interface;

namespace AspNet.Core.Web.App.Repo.Implementation
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly TestDatabaseContext _testDatabaseContext;

        public CustomerRepository(IOrmservice ormservice)
        {
            _testDatabaseContext = (ormservice as TestDatabaseContext);
        }

        public Customer Save(Customer entity)
        {
            var customerDb = CustomerMapper.Map(entity);

            _testDatabaseContext.Customer.Add(customerDb);

            _testDatabaseContext.SaveChanges();

            entity = CustomerMapper.Map(customerDb);

            return entity;
        }

        public IEnumerable<Customer> GetEntities()
        {
            var customersDb = _testDatabaseContext.Customer.Include("Address");

            var customers = new List<Customer>();

            foreach (var customer in customersDb)
            {
                var mappedCustomer = CustomerMapper.Map(customer);

                mappedCustomer.Addresses = new List<Address>();

                foreach (var address in customer.Address)
                {
                    var mappedAddress = AddressMapper.Map(address);
                    mappedCustomer.Addresses.Add(mappedAddress);
                }

                customers.Add(mappedCustomer);
            }

            return customers;
        }

        public Task<IEnumerable<Customer>> GetEntitiesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Customer> SaveAsync(Customer entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
