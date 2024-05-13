using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Pri.Vue.Store.Api.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
