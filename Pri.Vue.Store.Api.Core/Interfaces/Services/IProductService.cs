using Pri.Vue.Store.Api.Core.Entities;
using Pri.Vue.Store.Api.Core.Models.Products;
using Pri.Vue.Store.Api.Core.Models.Results;

namespace Pri.Vue.Store.Api.Core.Interfaces.Services
{
    public interface IProductService
    {
        Task<ServiceResultModel<IEnumerable<Product>>> ListAllAsync();
        Task<ServiceResultModel<Product>> GetByIdAsync(Guid id);
        Task<ServiceResultModel<Product>> CreateAsync(NewProductModel product);
        Task<ServiceResultModel<Product>> UpdateAsync(UpdateProductModel product);
        Task<ServiceResultModel<Product>> DeleteAsync(Guid id);
        Task<ServiceResultModel<IEnumerable<Product>>> Search(string search);
    }
}
