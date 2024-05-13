using Pri.Vue.Store.Api.Core.Entities;
using Pri.Vue.Store.Api.Core.Models.Products;

namespace Pri.Vue.Store.Api.Core.Mappings
{
    public static class ProductEntityMappings
    {
        public static Product MapToEntity(this UpdateProductModel updateProductModel, Product existingProduct)
        {
            existingProduct.Id = updateProductModel.Id;
            existingProduct.Name = updateProductModel.Name;
            existingProduct.Price = updateProductModel.Price;
            existingProduct.CategoryId = updateProductModel.CategoryId;
            existingProduct.PegiRating = updateProductModel.PegiRating;
            existingProduct.Description = updateProductModel.Description;

            return existingProduct;
        }

        public static Product MapToEntity(this NewProductModel newProductModel)
        {
            return new Product
            {
                Name = newProductModel.Name,
                Price = newProductModel.Price,
                CategoryId = newProductModel.CategoryId,
                PegiRating = newProductModel.PegiRating,
                Description = newProductModel.Description,
                ImageUrl = ApplicationConstants.DefaultProductImageUrl
            };
        }
    }
}
