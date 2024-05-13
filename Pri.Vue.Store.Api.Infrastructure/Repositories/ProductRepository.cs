using Microsoft.EntityFrameworkCore;
using Pri.Vue.Store.Api.Core.Entities;
using Pri.Vue.Store.Api.Core.Exceptions;
using Pri.Vue.Store.Api.Core.Interfaces.Repositories;
using Pri.Vue.Store.Api.Infrastructure.Data;
using System.Linq.Expressions;

namespace Pri.Vue.Store.Api.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(StoreDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Product> GetByIdAsync(Guid id)
        {
            try
            {
                var product = await _dbContext.Products
                    .Include(p => p.Category)
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (product == null)
                {
                    throw new NotFoundException(nameof(Product), id);
                }
                return product;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Product>> GetFilteredListAsync(Expression<Func<Product, bool>> predicate, bool includeCategories = false)
        {
            try
            {
                var query = GetAll();

                if (includeCategories)
                {
                    query = query.Include(p => p.Category);
                }

                return await query.Where(predicate).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
