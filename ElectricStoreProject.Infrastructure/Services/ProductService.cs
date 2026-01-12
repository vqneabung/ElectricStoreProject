using Common;
using ElectricStoreProject.Application.DTOs.Request;
using ElectricStoreProject.Application.Interface.Services;
using OneOf;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        public Task<OneOf<BaseSuccess, BaseError>> CreateBlogAsync(CommonProductRequest createBlogRequest)
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<BaseSuccess, BaseError>> DeleteBlogAsync(Guid blogId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CommonProductRequest>> GetAllProductAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<CommonProductRequest, BaseError>> GetProductByIdAsync(Guid ProductId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CommonProductRequest>> GetProductsByCategoryAsync(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<BaseSuccess, BaseError>> UpdateProductAsync(Guid id, CommonProductRequest updateBlogRequest)
        {
            throw new NotImplementedException();
        }
    }
}
