using AutoMapper;
using Common;
using Common.Repository;
using ElectricStoreProject.Application.DTOs.Request;
using ElectricStoreProject.Application.DTOs.Response;
using ElectricStoreProject.Application.Interface.Repositories;
using ElectricStoreProject.Application.Interface.Services;
using ElectricStoreProject.Domain.Entities;
using OneOf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElectricStoreProject.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OneOf<BaseSuccess, BaseError>> CreateCategoryAsync(CommonCategoryRequest createCategoryRequest)
        {

            var category = new Category
            {
                Name = createCategoryRequest.Name
            };

            try
            {
                await _unitOfWork.CategoryRepository.AddAsync(category);
                var saved = await _unitOfWork.CategoryRepository.SaveChangesAsync();
                if (saved)
                {
                    return new BaseSuccess(category.Id.ToString());
                }
                else
                {
                    return new BaseError { Message = "Failed to save category." };
                }
            }
            catch (Exception ex)
            {
                return new BaseError { Message = ex.Message };
            }
        }

        public async Task<OneOf<BaseSuccess, BaseError>> DeleteCategoryAsync(Guid categoryId)
        {
            try
            {
                var category = await _unitOfWork.CategoryRepository.GetByIdAsync(c => c.Id == categoryId);

                if (category == null)
                {
                    return new BaseError { Message = "Category not found." };
                }

                await _unitOfWork.CategoryRepository.SoftRemove(category);
                var saved = await _unitOfWork.CategoryRepository.SaveChangesAsync();

                return saved ? new BaseSuccess() : new BaseError { Message = "Failed to delete category." };

            }
            catch (Exception ex)
            {
                return new BaseError { Message = ex.Message };
            }
        }

        public async Task<IEnumerable<CommonCategoryResponse>> GetAllCategoryAsync()
        {
            try
            {
                var categories = await _unitOfWork.CategoryRepository.GetAllAsync(c => c.IsActive == true);
                return _mapper.Map<IEnumerable<CommonCategoryResponse>>(categories);

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving categories.", ex);
            }
        }

        public async Task<OneOf<CommonCategoryResponse, BaseError>> GetCategoryByIdAsync(Guid categoryId)
        {
            try
            {
                var category = await _unitOfWork.CategoryRepository.GetByIdAsync(c => c.Id == categoryId);
                return category != null
                    ? _mapper.Map<CommonCategoryResponse>(category)
                    : new BaseError { Message = "Category not found." };

            }
            catch (Exception ex)
            {
                return new BaseError { Message = ex.Message };
            }
        }


        public Task<OneOf<BaseSuccess, BaseError>> UpdateCategoryAsync(Guid id, CommonCategoryRequest updateCategoryRequest)
        {
            try
            {
                var categoryTask = _unitOfWork.CategoryRepository.GetByIdAsync(c => c.Id == id && c.IsActive == true);
                categoryTask.Wait();
                var category = categoryTask.Result;
                if (category == null)
                {
                    return Task.FromResult<OneOf<BaseSuccess, BaseError>>(new BaseError { Message = "Category not found." });
                }
                category.Name = updateCategoryRequest.Name;
                _unitOfWork.CategoryRepository.Update(category);
                var saveTask = _unitOfWork.CategoryRepository.SaveChangesAsync();
                saveTask.Wait();
                if (saveTask.Result)
                {
                    return Task.FromResult<OneOf<BaseSuccess, BaseError>>(new BaseSuccess());
                }
                else
                {
                    return Task.FromResult<OneOf<BaseSuccess, BaseError>>(new BaseError { Message = "Failed to update category." });
                }

            }
            catch (Exception ex)
            {
                return Task.FromResult<OneOf<BaseSuccess, BaseError>>(new BaseError { Message = ex.Message });
            }
        }

    }
}
