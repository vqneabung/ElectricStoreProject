using Common;
using ElectricStoreProject.Application.DTOs.Request;
using OneOf;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Application.Interface.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<CommonOrderRequest>> GetAllOrderAsync();

        Task<OneOf<CommonOrderRequest, BaseError>> GetOrderByIdAsync(Guid OrderId);

        Task<IEnumerable<CommonOrderRequest>> GetOrdersByCategoryAsync(Guid categoryId);

        Task<OneOf<BaseSuccess, BaseError>> UpdateOrderAsync(Guid id, CommonOrderRequest updateBlogRequest);

        Task<OneOf<BaseSuccess, BaseError>> CreateBlogAsync(CommonOrderRequest createBlogRequest);

        Task<OneOf<BaseSuccess, BaseError>> DeleteBlogAsync(Guid blogId);
    }
}
