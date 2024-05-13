using Pri.Vue.Store.Api.Core.Entities;
using Pri.Vue.Store.Api.Dtos.Categories;
using Pri.Vue.Store.Api.Dtos.Products;

namespace Pri.Vue.Store.Api.Mapping
{
    public interface IMapper
    {
        CategoryDto CreateCategoryDto(Category category);
        IEnumerable<CategoryDto> CreateCategoryDtos(IEnumerable<Category> categories);
        DetailProductDto CreateProductDetailDto(Product product);
        ProductDto CreateProductDto(Product product);
        IEnumerable<ProductDto> CreateProductDtos(IEnumerable<Product> products);
    }
}