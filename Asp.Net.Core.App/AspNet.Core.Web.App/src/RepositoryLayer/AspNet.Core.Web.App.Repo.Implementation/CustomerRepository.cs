﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AspNet.Core.Web.App.Repo.Interface;
using AspNet.Core.Web.Domains;

namespace AspNet.Core.Web.App.Repo.Implementation
{
    public class CustomerRepository : IRepository<Customer>
    {
        public CustomerRepository()
        {
        }

        public Customer Save(Customer entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Customer> GetEntities()
        {
            throw new System.NotImplementedException();
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