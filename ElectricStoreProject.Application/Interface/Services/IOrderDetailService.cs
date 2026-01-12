using Common;
using ElectricStoreProject.Application.DTOs.Request;
using ElectricStoreProject.Application.DTOs.Response;
using OneOf;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Application.Interface.Services
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<CommonOrderDetailResponse>> GetAllOrderDetailAsync();

        Task<OneOf<CommonOrderDetailResponse, BaseError>> GetOrderDetailByIdAsync(Guid orderDetailId);

        Task<OneOf<BaseSuccess, BaseError>> UpdateOrderDetailAsync(Guid id, CommonOrderDetailRequest updateOrderDetailRequest);

        Task<OneOf<BaseSuccess, BaseError>> CreateOrderDetailAsync(CommonOrderDetailRequest createOrderDetailRequest);

        Task<OneOf<BaseSuccess, BaseError>> DeleteOrderDetailAsync(Guid orderDetailId);
    }
}
