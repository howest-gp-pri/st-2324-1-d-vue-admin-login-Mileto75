using Microsoft.EntityFrameworkCore;
using Pri.Vue.Store.Api.Core.Entities;
using Pri.Vue.Store.Api.Core.Interfaces.Repositories;
using Pri.Vue.Store.Api.Infrastructure.Data;
using System.Linq.Expressions;

namespace Pri.Vue.Store.Api.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(StoreDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Category>> GetFilteredListAsync(Expression<Func<Category, bool>> predicate)
        {
            return await GetAll().Where(predicate).ToListAsync();
        }
    }
}
