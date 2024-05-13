﻿using Pri.Vue.Store.Api.Core.Entities;

namespace Pri.Vue.Store.Api.Dtos.Products
{
    public class NewProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Guid CategoryId { get; set; }
        public int? PegiRating { get; set; }
    }
}