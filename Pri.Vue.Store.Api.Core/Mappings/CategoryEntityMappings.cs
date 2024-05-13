using Pri.Vue.Store.Api.Core.Entities;
using Pri.Vue.Store.Api.Core.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Vue.Store.Api.Core.Mappings
{
    public static class CategoryEntityMappings
    {
        public static Category MapToEntity(this UpdateCategoryModel updateCategoryModel, Category existingCategory)
        {
            existingCategory.Id = updateCategoryModel.Id;
            existingCategory.Name = updateCategoryModel.Name;
            return existingCategory;
        }

        public static Category MapToEntity(this NewCategoryModel newCategoryModel)
        {
            return new Category
            {
                Name= newCategoryModel.Name,
                ImageUrl = ApplicationConstants.DefaultCategoryImageUrl
            };
        }
    }
}
