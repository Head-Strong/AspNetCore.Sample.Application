using System;
using AspNet.Core.Web.Domains;
using Customer = EntityFramework.Core.Models.Customer;

namespace AspNet.Core.Web.App.Repo.Implementation.Mapper
{
    public static class AddressMapper
    {
        public static Address Map(EntityFramework.Core.Models.Address address)
        {
            var domainAddress = new Address
            {
                Id = address.Id,
                CustomerId = address.CustomerId,
                Pin = address.Pin
            };

            return domainAddress;
        }

        public static EntityFramework.Core.Models.Address Map(Address address)
        {
            var entityAddress = new EntityFramework.Core.Models.Address
            {
                Id = address.Id,
                CustomerId = address.CustomerId,
                Pin = address.Pin
            };

            return entityAddress;
        }

        public static EntityFramework.Core.Models.Address Map(Address address, Customer customer)
        {
            var entityAddress = new EntityFramework.Core.Models.Address
            {
                Id = address.Id,
                CustomerId = address.Id,
                Pin = address.Pin,
                Customer = customer
            };

            return entityAddress;
        }
    }
}