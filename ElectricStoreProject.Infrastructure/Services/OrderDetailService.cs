using Common;
using ElectricStoreProject.Application.DTOs.Request;
using ElectricStoreProject.Application.Interface.Services;
using OneOf;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Infrastructure.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        public Task<OneOf<BaseSuccess, BaseError>> CreateOrderDetailAsync(CommonOrderDetailRequest createBlogRequest)
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<BaseSuccess, BaseError>> DeleteOrderDetailAsync(Guid blogId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CommonOrderDetailRequest>> GetAllOrderDetailAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<CommonOrderDetailRequest, BaseError>> GetOrderDetailByIdAsync(Guid OrderDetailId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CommonOrderDetailRequest>> GetOrderDetailsByCategoryAsync(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<BaseSuccess, BaseError>> UpdateOrderDetailAsync(Guid id, CommonOrderDetailRequest updateBlogRequest)
        {
            throw new NotImplementedException();
        }
    }
}
