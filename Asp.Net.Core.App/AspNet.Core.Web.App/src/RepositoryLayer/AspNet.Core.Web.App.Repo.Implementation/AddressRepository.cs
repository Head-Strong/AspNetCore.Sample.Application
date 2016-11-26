using System.Collections.Generic;
using System.Threading.Tasks;
using AspNet.Core.Web.App.Repo.Interface;
using AspNet.Core.Web.Domains;

namespace AspNet.Core.Web.App.Repo.Implementation
{
    public class AddressRepository : IRepository<Address>
    {
        public Address Save(Address entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Address> GetEntities()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Address>> GetEntitiesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Address> SaveAsync(Address entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
