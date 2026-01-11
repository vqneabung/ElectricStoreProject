using Common;
using ElectricStoreProject.Application.DTOs.Request;
using OneOf;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Application.Interface.Services
{
    public interface ICategoryService
    {

        Task<IEnumerable<CommonCategoryRequest>> GetAllCategoryAsync();

        Task<OneOf<CommonCategoryRequest, BaseError>> GetCategoryByIdAsync(Guid CategoryId);

        Task<IEnumerable<CommonCategoryRequest>> GetCategorysByCategoryAsync(Guid categoryId);

        Task<OneOf<BaseSuccess, BaseError>> UpdateCategoryAsync(Guid id, CommonCategoryRequest updateBlogRequest);

        Task<OneOf<BaseSuccess, BaseError>> CreateBlogAsync(CommonCategoryRequest createBlogRequest);

        Task<OneOf<BaseSuccess, BaseError>> DeleteBlogAsync(Guid blogId);

    }
}
