using Common;
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
    public class OrdersController : ControllerBaseWithBaseReponse
    {
        private readonly IServiceProviders _serviceProviders;

        public OrdersController(IServiceProviders serviceProviders)
        {
            _serviceProviders = serviceProviders;
        }

        [HttpGet]
        public async Task<BaseActionResult<CommonOrderResponse>> GetAlls()
        {
            try
            {
                var result = await _serviceProviders.OrderService.GetAllOrderAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<BaseActionResult<CommonOrderResponse>> GetById(int id)
        {
            try
            {
                var result = await _serviceProviders.OrderService.GetOrderByIdAsync(Guid.Parse(id.ToString()));
                return result.Match(success => { return Ok(success); }, failed => { return BadRequest(failed); });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<BaseActionResult<CommonOrderResponse>> CreateOrder(CreateOrderRequest createOrderRequest)
        {
            try
            {
                // Implementation for creating an order goes here
                var result = await _serviceProviders.OrderService.CreateOrderAsync(createOrderRequest);
                return result.Match(success =>
                {
                    return Ok(success);
                }, failed =>
                {
                    return BadRequest(failed);
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<BaseActionResult<BaseSuccess>> DeleteOrder(int id)
        {
            try
            {
                var result = await _serviceProviders.OrderService.DeleteOrderAsync(Guid.Parse(id.ToString()));
                return result.Match(success =>
                {
                    return Ok(success);
                }, failed =>
                {
                    return BadRequest(failed);
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
