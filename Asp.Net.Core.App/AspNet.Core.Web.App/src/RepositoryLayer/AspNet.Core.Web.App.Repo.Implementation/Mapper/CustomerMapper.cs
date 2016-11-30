using System.Collections.Generic;
using Customer = AspNet.Core.Web.Domains.Customer;
using Address = AspNet.Core.Web.Domains.Address;

namespace AspNet.Core.Web.App.Repo.Implementation.Mapper
{
    public class CustomerMapper
    {
        public static Customer Map(EntityFramework.Core.Models.Customer customer)
        {
            var domainCustomer = new Customer
            {
                Id = customer.Id,
                Name = customer.Name,
                LastName = customer.LastName,
                Addresses = new List<Address>()
            };

            foreach (var address in customer.Address)
            {
                var domainAddress = AddressMapper.Map(address);

                domainCustomer.Addresses.Add(domainAddress);
            }

            return domainCustomer;
        }

        public static EntityFramework.Core.Models.Customer Map(Customer customer)
        {
            var entityCustomer = new EntityFramework.Core.Models.Customer
            {
                Id = customer.Id,
                Name = customer.Name,
                LastName = customer.LastName               
            };

            if (customer.Addresses != null)
            {
                foreach (var address in customer.Addresses)
                {
                    var entityAddress = AddressMapper.Map(address, entityCustomer);

                    entityCustomer.Address.Add(entityAddress);
                }
            }

            return entityCustomer;
        }
    }
}
