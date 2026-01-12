using Common;
using ElectricStoreProject.Application.DTOs.Request;
using OneOf;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Application.Interface.Services
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<CommonOrderDetailRequest>> GetAllOrderDetailAsync();

        Task<OneOf<CommonOrderDetailRequest, BaseError>> GetOrderDetailByIdAsync(Guid OrderDetailId);

        Task<IEnumerable<CommonOrderDetailRequest>> GetOrderDetailsByCategoryAsync(Guid categoryId);

        Task<OneOf<BaseSuccess, BaseError>> UpdateOrderDetailAsync(Guid id, CommonOrderDetailRequest updateOrderDetailRequest);

        Task<OneOf<BaseSuccess, BaseError>> CreateOrderDetailAsync(CommonOrderDetailRequest createOrderDetailRequest);

        Task<OneOf<BaseSuccess, BaseError>> DeleteOrderDetailAsync(Guid orderDetailId);
    }
}
