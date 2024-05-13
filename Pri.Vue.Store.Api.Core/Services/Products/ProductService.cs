using Pri.Vue.Store.Api.Core.Entities;
using Pri.Vue.Store.Api.Core.Interfaces.Repositories;
using Pri.Vue.Store.Api.Core.Interfaces.Services;
using Pri.Vue.Store.Api.Core.Mappings;
using Pri.Vue.Store.Api.Core.Models.Products;
using Pri.Vue.Store.Api.Core.Models.Results;
using System.ComponentModel.DataAnnotations;

namespace Pri.Vue.Store.Api.Core.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<ServiceResultModel<Product>> CreateAsync(NewProductModel product)
        {
            var result = new ServiceResultModel<Product>();

            try
            {
                if (await _categoryRepository.DoesExistAsync(product.CategoryId) == false)
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"{nameof(Category)} with id {product.CategoryId} was not found"));
                    return result;
                }

                var productEntity = product.MapToEntity();
                await _productRepository.CreateAsync(productEntity);
                result.IsSuccess = true;
                result.Data = productEntity;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult(ex.Message));
            }

            return result;
        }

        public async Task<ServiceResultModel<Product>> DeleteAsync(Guid id)
        {
            var result = new ServiceResultModel<Product>();

            try
            {
                if (await _productRepository.DoesExistAsync(id) == false)
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"Could not delete {id} because there is no {nameof(Product)} with this id"));
                }
                else
                {
                    await _productRepository.DeleteAsync(id);
                    result.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult(ex.Message));
            }

            return result;
        }

        public async Task<ServiceResultModel<Product>> GetByIdAsync(Guid id)
        {
            var result = new ServiceResultModel<Product>();

            try
            {
                var product = await _productRepository.GetByIdAsync(id);
                if (product == null)
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"{nameof(Product)} with id {id} does not exist"));
                    return result;
                }

                result.IsSuccess = true;
                result.Data = product;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult(ex.Message));
            }
            return result;
        }

        public async Task<ServiceResultModel<IEnumerable<Product>>> ListAllAsync()
        {
            var result = new ServiceResultModel<IEnumerable<Product>>();

            try
            {
                var products = await _productRepository.ListAllAsync();

                result.IsSuccess = true;
                result.Data = products;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult(ex.Message));
            }
            return result;
        }

        public async Task<ServiceResultModel<IEnumerable<Product>>> Search(string search)
        {
            var result = new ServiceResultModel<IEnumerable<Product>>();

            try
            {
                var products = await _productRepository.GetFilteredListAsync(c => c.Name.Contains(search) || c.Description.Contains(search));

                result.IsSuccess = true;
                result.Data = products;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult(ex.Message));
            }
            return result;
        }

        public async Task<ServiceResultModel<Product>> UpdateAsync(UpdateProductModel productModel)
        {
            var result = new ServiceResultModel<Product>();

            try
            {
                var existingProduct = await _productRepository.GetByIdAsync(productModel.Id);

                if (existingProduct == null)
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"{nameof(Product)} with id {productModel.Id} does not exist"));
                    return result;
                }

                if (await _categoryRepository.DoesExistAsync(productModel.CategoryId) == false)
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"{nameof(Category)} with id {productModel.CategoryId} was not found"));
                    return result;
                }

                await _productRepository.UpdateAsync(productModel.MapToEntity(existingProduct));
                result.IsSuccess = true;
                result.Data = existingProduct;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult(ex.Message));
            }

            return result;
        }
    }
}