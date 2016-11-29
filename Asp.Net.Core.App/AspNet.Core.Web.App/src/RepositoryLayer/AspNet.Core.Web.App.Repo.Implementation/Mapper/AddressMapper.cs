using AspNet.Core.Web.Domains;

namespace AspNet.Core.Web.App.Repo.Implementation.Mapper
{
    public static class AddressMapper
    {
        public static Address Map(EntityFramework.Core.Models.Address address)
        {
            var domainAddress = new Address
            {
                AddressId = address.AddressId,
                CustomerId = address.CustomerId,
                Pin = address.Pin
            };

            return domainAddress;
        }

        public static EntityFramework.Core.Models.Address Map(Address address)
        {
            var entityAddress = new EntityFramework.Core.Models.Address
            {
                AddressId = address.AddressId,
                CustomerId = address.CustomerId,
                Pin = address.Pin
            };

            return entityAddress;
        }
    }
}