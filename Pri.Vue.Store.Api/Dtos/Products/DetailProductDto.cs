namespace Pri.Vue.Store.Api.Dtos.Products
{
    public class DetailProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? PegiRating { get; set; }
    }
}