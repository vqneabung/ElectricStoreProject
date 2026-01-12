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
        Task<IEnumerable<CommonProductResponse>> GetAllProductAsync();

        Task<OneOf<CommonProductRequest, BaseError>> GetProductByIdAsync(Guid productId);

        Task<IEnumerable<CommonProductRequest>> GetProductsByCategoryAsync(Guid categoryId);

        Task<OneOf<BaseSuccess, BaseError>> UpdateProductAsync(Guid id, CommonProductRequest updateProductRequest);

        Task<OneOf<BaseSuccess, BaseError>> CreateProductAsync(CommonProductRequest createProductRequest);

        Task<OneOf<BaseSuccess, BaseError>> DeleteProductAsync(Guid productId);

    }
}
