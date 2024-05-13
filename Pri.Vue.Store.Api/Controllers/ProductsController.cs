using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pri.Vue.Store.Api.Core;
using Pri.Vue.Store.Api.Core.Entities;
using Pri.Vue.Store.Api.Core.Interfaces.Services;
using Pri.Vue.Store.Api.Core.Models.Products;
using Pri.Vue.Store.Api.Core.Models.Results;
using Pri.Vue.Store.Api.Dtos.Products;
using Pri.Vue.Store.Api.Mapping;

namespace Pri.Vue.Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = ApplicationConstants.AdminPolicyName)]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] string search)
        {
            var result = new ServiceResultModel<IEnumerable<Product>>();

            if (string.IsNullOrEmpty(search))
            {
                result = await _productService.ListAllAsync();
            }
            else
            {
                result = await _productService.Search(search);
            }

            if (result.IsSuccess == false)
            {
                return BadRequest(result.ValidationErrors);
            }
            IEnumerable<ProductDto> productDtos = _mapper.CreateProductDtos(result.Data);

            return Ok(productDtos);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _productService.GetByIdAsync(id);

            if (result.IsSuccess == false)
            {
                return BadRequest(result.ValidationErrors);
            }
            DetailProductDto productDto = _mapper.CreateProductDetailDto(result.Data);

            return Ok(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewProductDto newProductDto)
        {
            var model = new NewProductModel
            {
                Name = newProductDto.Name,
                CategoryId = newProductDto.CategoryId,
                Description = newProductDto.Description,
                PegiRating = newProductDto.PegiRating,
                Price = newProductDto.Price
            };

            var result = await _productService.CreateAsync(model);

            if (result.IsSuccess == false)
            {
                return BadRequest(result.ValidationErrors);
            }

            var dto = _mapper.CreateProductDto(result.Data);

            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
        {
            var model = new UpdateProductModel
            {
                Name = updateProductDto.Name,
                Id = updateProductDto.Id,
                CategoryId = updateProductDto.CategoryId,
                Description = updateProductDto.Description,
                PegiRating = updateProductDto.PegiRating,
                Price = updateProductDto.Price
            };
            var result = await _productService.UpdateAsync(model);

            if (result.IsSuccess == false)
            {
                return BadRequest(result.ValidationErrors);
            }

            var dto = _mapper.CreateProductDto(result.Data);

            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _productService.DeleteAsync(id);

            if (result.IsSuccess == false)
            {
                return BadRequest(result.ValidationErrors);
            }
            return Ok();
        }
    }
}
