using Common;
using ElectricStoreProject.Application.DTOs.Request;
using ElectricStoreProject.Application.DTOs.Response;
using OneOf;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Application.Interface.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<CommonOrderResponse>> GetAllOrderAsync();

        Task<OneOf<CommonOrderResponse, BaseError>> GetOrderByIdAsync(Guid orderId);

        Task<IEnumerable<CommonOrderResponse>> GetOrdersByOrderAsync(Guid OrderId);

        Task<OneOf<BaseSuccess, BaseError>> UpdateOrderAsync(Guid id, CommonOrderRequest updateOrderRequest);

        Task<OneOf<BaseSuccess, BaseError>> CreateOrderAsync(CreateOrderRequest createOrderRequest);

        Task<OneOf<BaseSuccess, BaseError>> DeleteOrderAsync(Guid OrderId);
    }
}
