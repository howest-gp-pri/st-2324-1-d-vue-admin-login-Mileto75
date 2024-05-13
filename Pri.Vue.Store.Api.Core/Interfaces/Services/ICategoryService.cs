using Pri.Vue.Store.Api.Core.Entities;
using Pri.Vue.Store.Api.Core.Models.Categories;
using Pri.Vue.Store.Api.Core.Models.Results;

namespace Pri.Vue.Store.Api.Core.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<ServiceResultModel<IEnumerable<Category>>> ListAllAsync();
        Task<ServiceResultModel<IEnumerable<Category>>> Search(string search);
        Task<ServiceResultModel<Category>> GetByIdAsync(Guid id);
        Task<ServiceResultModel<Category>> CreateAsync(NewCategoryModel category);
        Task<ServiceResultModel<Category>> UpdateAsync(UpdateCategoryModel category);
        Task<ServiceResultModel<Category>> DeleteAsync(Guid id);
        Task<ServiceResultModel<IEnumerable<Product>>> GetProductsFromCategoryIdAsync(Guid id);
    }
}
