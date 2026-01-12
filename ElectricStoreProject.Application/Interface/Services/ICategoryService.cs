using Common;
using ElectricStoreProject.Application.DTOs.Request;
using ElectricStoreProject.Application.DTOs.Response;
using OneOf;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Application.Interface.Services
{
    public interface ICategoryService
    {

        Task<IEnumerable<CommonCategoryResponse>> GetAllCategoryAsync();

        Task<OneOf<CommonOrderDetailResponse, BaseError>> GetCategoryByIdAsync(Guid categoryId);

        Task<OneOf<BaseSuccess, BaseError>> UpdateCategoryAsync(Guid id, CommonCategoryRequest updateCategoryRequest);

        Task<OneOf<BaseSuccess, BaseError>> CreateCategoryAsync(CommonCategoryRequest createCategoryRequest);

        Task<OneOf<BaseSuccess, BaseError>> DeleteCategoryAsync(Guid categoryId);

    }
}
