using Common;
using Common.Repository;
using ElectricStoreProject.Application.DTOs.Request;
using ElectricStoreProject.Application.Interface.Services;
using OneOf;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        public Task<OneOf<BaseSuccess, BaseError>> CreateCategoryAsync(CommonCategoryRequest createCategoryRequest)
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<BaseSuccess, BaseError>> DeleteCategoryAsync(Guid CategoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CommonCategoryRequest>> GetAllCategoryAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<CommonCategoryRequest, BaseError>> GetCategoryByIdAsync(Guid CategoryId)
        {
            throw new NotImplementedException();
        }
        
        public Task<IEnumerable<CommonCategoryRequest>> GetCategorysByCategoryAsync(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<BaseSuccess, BaseError>> UpdateCategoryAsync(Guid id, CommonCategoryRequest updateCategoryRequest)
        {
            throw new NotImplementedException();
        }
    }
}
