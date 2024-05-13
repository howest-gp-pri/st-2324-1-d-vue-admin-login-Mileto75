using Pri.Vue.Store.Api.Core.Entities;

namespace Pri.Vue.Store.Api.Core.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<T>> ListAllAsync();
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(Guid id);
        Task<bool> DoesExistAsync(Guid id);
    }
}
