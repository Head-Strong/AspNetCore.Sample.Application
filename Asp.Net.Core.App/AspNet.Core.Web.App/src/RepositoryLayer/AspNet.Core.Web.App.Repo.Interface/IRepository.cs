using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNet.Core.Web.App.Repo.Interface
{
    public interface IRepository<T>
    {
        T Save(T entity);

        IEnumerable<T> GetEntities();

        Task<IEnumerable<T>> GetEntitiesAsync();

        Task<T> SaveAsync(T entity);
    }
}
