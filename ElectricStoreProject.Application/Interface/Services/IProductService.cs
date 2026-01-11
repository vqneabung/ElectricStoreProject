using Common;
using ElectricStoreProject.Application.DTOs.Request;
using ElectricStoreProject.Application.DTOs.Response;
using OneOf;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Application.Interface.Services
{
    public interface IProductService
    {
        Task<IEnumerable<CommonProductRequest>> GetAllProductAsync();

        Task<OneOf<CommonProductRequest, BaseError>> GetProductByIdAsync(Guid ProductId);

        Task<IEnumerable<CommonProductRequest>> GetProductsByCategoryAsync(Guid categoryId);

        Task<OneOf<BaseSuccess, BaseError>> UpdateProductAsync(Guid id, CommonProductRequest updateBlogRequest);

        Task<OneOf<BaseSuccess, BaseError>> CreateBlogAsync(CommonProductRequest createBlogRequest);

        Task<OneOf<BaseSuccess, BaseError>> DeleteBlogAsync(Guid blogId);

    }
}
