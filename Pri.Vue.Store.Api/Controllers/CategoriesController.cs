using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pri.Vue.Store.Api.Core;
using Pri.Vue.Store.Api.Core.Entities;
using Pri.Vue.Store.Api.Core.Interfaces.Services;
using Pri.Vue.Store.Api.Core.Models.Categories;
using Pri.Vue.Store.Api.Core.Models.Results;
using Pri.Vue.Store.Api.Dtos.Categories;
using Pri.Vue.Store.Api.Dtos.Products;
using Pri.Vue.Store.Api.Mapping;

namespace Pri.Vue.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = ApplicationConstants.AdminPolicyName)]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] string search)
        {
            var result = new ServiceResultModel<IEnumerable<Category>>();

            if (string.IsNullOrEmpty(search))
            {
                result = await _categoryService.ListAllAsync();
            }
            else
            {
                result = await _categoryService.Search(search);
            }

            if (result.IsSuccess == false)
            {
                return BadRequest(result.ValidationErrors);
            }
            IEnumerable<CategoryDto> categoryDtos = _mapper.CreateCategoryDtos(result.Data);

            return Ok(categoryDtos);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _categoryService.GetByIdAsync(id);

            if (result.IsSuccess == false)
            {
                return BadRequest(result.ValidationErrors);
            }
            CategoryDto categoryDto = _mapper.CreateCategoryDto(result.Data);

            return Ok(categoryDto);
        }

        [HttpGet("{id}/products")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProductsFromCategoryId(Guid id)
        {
            var result = await _categoryService.GetProductsFromCategoryIdAsync(id);

            if (result.IsSuccess == false)
            {
                return BadRequest(result.ValidationErrors);
            }
            IEnumerable<ProductDto> productDtos = _mapper.CreateProductDtos(result.Data);

            return Ok(productDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewCategoryDto newCategoryDto)
        {
            var model = new NewCategoryModel { Name = newCategoryDto.Name };
            var result = await _categoryService.CreateAsync(model);

            if (result.IsSuccess == false)
            {
                return BadRequest(result.ValidationErrors);
            }

            var dto = _mapper.CreateCategoryDto(result.Data);

            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto)
        {
            var model = new UpdateCategoryModel { Name = updateCategoryDto.Name, Id = updateCategoryDto.Id };
            var result = await _categoryService.UpdateAsync(model);

            if (result.IsSuccess == false)
            {
                return BadRequest(result.ValidationErrors);
            }

            var dto = _mapper.CreateCategoryDto(result.Data);

            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _categoryService.DeleteAsync(id);

            if (result.IsSuccess == false)
            {
                return BadRequest(result.ValidationErrors);
            }
            return Ok();
        }
    }
}
