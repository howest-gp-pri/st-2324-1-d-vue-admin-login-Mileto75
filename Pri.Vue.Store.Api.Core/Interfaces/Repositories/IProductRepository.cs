using Pri.Vue.Store.Api.Core.Entities;
using System.Linq.Expressions;

namespace Pri.Vue.Store.Api.Core.Interfaces.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> GetFilteredListAsync(Expression<Func<Product, bool>> predicate, bool includeCategories = false);
    }
}
