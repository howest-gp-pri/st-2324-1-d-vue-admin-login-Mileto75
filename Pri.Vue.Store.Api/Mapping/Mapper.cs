using Pri.Vue.Store.Api.Core.Entities;
using Pri.Vue.Store.Api.Dtos.Categories;
using Pri.Vue.Store.Api.Dtos.Products;

namespace Pri.Vue.Store.Api.Mapping
{
    public class Mapper : IMapper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _baseAddress;

        public Mapper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _baseAddress = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
        }

        public CategoryDto CreateCategoryDto(Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                ImageUrl = $"{_baseAddress}/{category.ImageUrl}",
            };
        }

        public IEnumerable<CategoryDto> CreateCategoryDtos(IEnumerable<Category> categories)
        {
            return categories.Select(c => CreateCategoryDto(c));
        }

        public ProductDto CreateProductDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                ImageUrl = $"{_baseAddress}/{product.ImageUrl}",
                Price = product.Price,
            };
        }

        public DetailProductDto CreateProductDetailDto(Product product)
        {
            return new DetailProductDto
            {
                Id = product.Id,
                Name = product.Name,
                ImageUrl = $"{_baseAddress}/{product.ImageUrl}",
                Price = product.Price,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name,
                Description = product.Description,
                PegiRating = product.PegiRating
            };
        }

        public IEnumerable<ProductDto> CreateProductDtos(IEnumerable<Product> products)
        {
            return products.Select(p => CreateProductDto(p));
        }
    }
}
