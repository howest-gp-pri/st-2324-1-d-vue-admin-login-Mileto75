using Pri.Vue.Store.Api.Core.Entities;

namespace Pri.Vue.Store.Api.Dtos.Products
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
    }
}