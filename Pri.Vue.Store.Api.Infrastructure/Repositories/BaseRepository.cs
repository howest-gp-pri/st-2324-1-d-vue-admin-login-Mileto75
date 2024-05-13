using Microsoft.EntityFrameworkCore;
using Pri.Vue.Store.Api.Core.Entities;
using Pri.Vue.Store.Api.Core.Exceptions;
using Pri.Vue.Store.Api.Core.Interfaces.Repositories;
using Pri.Vue.Store.Api.Infrastructure.Data;

namespace Pri.Vue.Store.Api.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly StoreDbContext _dbContext;

        protected BaseRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DoesExistAsync(Guid id)
        {
            try
            {
                return await _dbContext.Set<T>().AnyAsync(t => t.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Something went wrong when checking if {typeof(T).Name} with id {id} already exists database", ex.InnerException);
            }
        }

        public async Task CreateAsync(T entity)
        {
            try
            {
                await _dbContext.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Something went wrong when creating {typeof(T).Name} with id {entity.Id}", ex.InnerException);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var entity = await _dbContext.Set<T>().FirstOrDefaultAsync(t => t.Id.Equals(id));
                if (entity is null)
                {
                    throw new NotFoundException(nameof(T), id);
                }
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Something went wrong when deleting {typeof(T).Name} with id {id} from database", ex.InnerException);
            }
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                return await _dbContext.Set<T>().FirstOrDefaultAsync(t => t.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw new Exception($"Something went wrong when retrieving {typeof(T).Name} with id {id} from database", ex.InnerException);
            }
        }

        public virtual async Task<IEnumerable<T>> ListAllAsync()
        {
            try
            {
                return await _dbContext.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Something went wrong when retrieving a list of type {typeof(T).Name} from database", ex.InnerException);
            }
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                _dbContext.Set<T>().Update(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Something went wrong when updating database for {typeof(T).Name} with id {entity.Id}", ex.InnerException);
            }
        }
    }
}
