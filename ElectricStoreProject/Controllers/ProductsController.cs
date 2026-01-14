using Common.Extensions;
using ElectricStoreProject.Application.DTOs.Request;
using ElectricStoreProject.Application.DTOs.Response;
using ElectricStoreProject.Application.Interface.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectricStoreProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBaseWithBaseReponse
    {
        private readonly IServiceProviders _serviceProviders;

        public ProductsController(IServiceProviders serviceProviders)
        {
            _serviceProviders = serviceProviders;
        }

        [HttpGet]
        public async Task<BaseActionResult<IEnumerable<CommonProductResponse>>> GetAlls()
        {
            try
            {
                var result = await _serviceProviders.ProductService.GetAllProductAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<BaseActionResult<CommonProductResponse>> GetById(int id)
        {
            try
            {
                var result = await _serviceProviders.ProductService.GetProductByIdAsync(Guid.Parse(id.ToString()));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<BaseActionResult<CommonProductResponse>> CreateProduct([FromBody] CommonProductRequest productRequest)
        {
            try
            {
                var result = await _serviceProviders.ProductService.CreateProductAsync(productRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<BaseActionResult<CommonProductResponse>> UpdateProduct(int id, [FromBody] CommonProductRequest productRequest)
        {
            try
            {
                var result = await _serviceProviders.ProductService.UpdateProductAsync(Guid.Parse(id.ToString()), productRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<BaseActionResult<CommonProductResponse>> DeleteProduct(int id)
        {
            try
            {
                var result = await _serviceProviders.ProductService.DeleteProductAsync(Guid.Parse(id.ToString()));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
