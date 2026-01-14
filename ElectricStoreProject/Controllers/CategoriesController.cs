using Common;
using Common.Extensions;
using ElectricStoreProject.Application.DTOs.Response;
using ElectricStoreProject.Application.Interface.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectricStoreProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBaseWithBaseReponse
    {
        private readonly IServiceProviders _serviceProviders;

        public CategoriesController(IServiceProviders serviceProviders)
        {
            _serviceProviders = serviceProviders;
        }

        [HttpGet]
        public async Task<BaseActionResult<IEnumerable<CommonCategoryResponse>>> GetAllCategories()
        {
            try
            {
                var result = await _serviceProviders.CategoryService.GetAllCategoryAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<BaseActionResult<CommonCategoryResponse>> GetCategoryById(int id)
        {
            try
            {
                var result = await _serviceProviders.CategoryService.GetCategoryByIdAsync(Guid.Parse(id.ToString()));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<BaseActionResult<BaseSuccess>> DeleteCategory(int id)
        {
            try
            {
                var result = await _serviceProviders.CategoryService.DeleteCategoryAsync(Guid.Parse(id.ToString()));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
