using Pri.Vue.Store.Api.Core.Entities;
using System.Linq.Expressions;

namespace Pri.Vue.Store.Api.Core.Interfaces.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<IEnumerable<Category>> GetFilteredListAsync(Expression<Func<Category, bool>> predicate);
    }
}
