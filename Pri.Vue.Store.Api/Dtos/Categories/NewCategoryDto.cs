using System.ComponentModel.DataAnnotations;

namespace Pri.Vue.Store.Api.Dtos.Categories
{
    public class NewCategoryDto
    {
        [Required]
        public string Name { get; set; }
    }
}