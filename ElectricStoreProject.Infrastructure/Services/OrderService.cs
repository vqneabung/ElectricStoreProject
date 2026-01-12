using Common;
using ElectricStoreProject.Application.DTOs.Request;
using ElectricStoreProject.Application.Interface.Services;
using OneOf;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        public Task<OneOf<BaseSuccess, BaseError>> CreateCategoryAsync(CommonOrderRequest createBlogRequest)
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<BaseSuccess, BaseError>> DeleteCategoryAsync(Guid blogId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CommonOrderRequest>> GetAllOrderAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<CommonOrderRequest, BaseError>> GetOrderByIdAsync(Guid OrderId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CommonOrderRequest>> GetOrdersByCategoryAsync(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<BaseSuccess, BaseError>> UpdateOrderAsync(Guid id, CommonOrderRequest updateBlogRequest)
        {
            throw new NotImplementedException();
        }
    }
}
