using Pri.Vue.Store.Api.Core.Entities;
using Pri.Vue.Store.Api.Core.Interfaces.Repositories;
using Pri.Vue.Store.Api.Core.Interfaces.Services;
using Pri.Vue.Store.Api.Core.Mappings;
using Pri.Vue.Store.Api.Core.Models.Categories;
using Pri.Vue.Store.Api.Core.Models.Results;
using System.ComponentModel.DataAnnotations;

namespace Pri.Vue.Store.Api.Core.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public CategoryService(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public async Task<ServiceResultModel<Category>> CreateAsync(NewCategoryModel category)
        {
            var result = new ServiceResultModel<Category>();

            try
            {
                var categoryEntity = category.MapToEntity();
                await _categoryRepository.CreateAsync(categoryEntity);
                result.IsSuccess = true;
                result.Data = categoryEntity;
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult(ex.Message));
                return result;
            }
        }

        public async Task<ServiceResultModel<Category>> DeleteAsync(Guid id)
        {
            var result = new ServiceResultModel<Category>();

            try
            {
                if (await _categoryRepository.DoesExistAsync(id) == false)
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"Could not delete {id} because there is no {nameof(Category)} with this id"));
                }
                else if(await DoesCategoryHasProducts(id))
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"Could not delete {id} because there are products linked to a {nameof(Category)} with this id"));
                }
                else
                {
                    await _categoryRepository.DeleteAsync(id);
                    result.IsSuccess = true;
                }
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult(ex.Message));
                return result;
            }
        }

        private async Task<bool> DoesCategoryHasProducts(Guid id)
        {
            var result = await GetProductsFromCategoryIdAsync(id);
            if (result.IsSuccess)
            {
                if (result.Data.Any())
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<ServiceResultModel<Category>> GetByIdAsync(Guid id)
        {
            var result = new ServiceResultModel<Category>();

            try
            {
                var category = await _categoryRepository.GetByIdAsync(id);
                if (category == null)
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"{nameof(Category)} with id {id} does not exist"));
                    return result;
                }

                result.IsSuccess = true;
                result.Data = category;
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult(ex.Message));
                return result;
            }
        }

        public async Task<ServiceResultModel<IEnumerable<Product>>> GetProductsFromCategoryIdAsync(Guid id)
        {
            var result = new ServiceResultModel<IEnumerable<Product>>();

            try
            {
                var products = await _productRepository.GetFilteredListAsync(p => p.CategoryId == id);

                result.IsSuccess = true;
                result.Data = products;
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult(ex.Message));
                return result;
            }
        }

        public async Task<ServiceResultModel<IEnumerable<Category>>> ListAllAsync()
        {
            var result = new ServiceResultModel<IEnumerable<Category>>();

            try
            {
                var categories = await _categoryRepository.ListAllAsync();

                result.IsSuccess = true;
                result.Data = categories;
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult(ex.Message));
                return result;
            }
        }

        public async Task<ServiceResultModel<IEnumerable<Category>>> Search(string search)
        {
            var result = new ServiceResultModel<IEnumerable<Category>>();

            try
            {
                var categories = await _categoryRepository.GetFilteredListAsync(c => c.Name.Contains(search));

                result.IsSuccess = true;
                result.Data = categories;
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult(ex.Message));
                return result;
            }
        }

        public async Task<ServiceResultModel<Category>> UpdateAsync(UpdateCategoryModel categoryModel)
        {
            var result = new ServiceResultModel<Category>();

            try
            {
                var existingCategory = await _categoryRepository.GetByIdAsync(categoryModel.Id);

                if (existingCategory == null)
                {
                    result.IsSuccess = false;
                    result.ValidationErrors.Add(new ValidationResult($"{nameof(Category)} with id {categoryModel.Id} does not exist"));
                    return result;
                }

                await _categoryRepository.UpdateAsync(categoryModel.MapToEntity(existingCategory));
                result.IsSuccess = true;
                result.Data = existingCategory;

                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ValidationErrors.Add(new ValidationResult(ex.Message));
                return result;
            }
        }
    }
}
