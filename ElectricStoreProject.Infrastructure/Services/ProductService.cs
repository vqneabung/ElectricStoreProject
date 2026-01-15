using AutoMapper;
using Common;
using ElectricStoreProject.Application.DTOs.Request;
using ElectricStoreProject.Application.DTOs.Response;
using ElectricStoreProject.Application.Interface.Repositories;
using ElectricStoreProject.Application.Interface.Services;
using ElectricStoreProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using OneOf;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OneOf<BaseSuccess, BaseError>> CreateProductAsync(CommonProductRequest createProductRequest)
        {
            try
            {
                await _unitOfWork.ProductRepository.AddAsyncWithSave(new Product
                {
                    UrlImage = createProductRequest.UrlImage,
                    Name = createProductRequest.Name,
                    CategoryId = createProductRequest.CategoryId,
                    Description = createProductRequest.Description,
                    Price = createProductRequest.Price,
                    StockQuantity = createProductRequest.StockQuantity
                });

                return new BaseSuccess
                {
                    Message = "Product created successfully."
                };
            }
            catch (Exception ex)
            {
                return new BaseError
                {
                    Message = "An error occurred while creating the product.",
                    Errors = ex.Message
                };
            }
        }

        public async Task<OneOf<BaseSuccess, BaseError>> DeleteProductAsync(Guid productId)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(p => p.Id == productId);
                if (product == null)
                {
                    return new BaseError
                    {
                        Message = "Product not found.",
                        Errors = $"No product found with ID: {productId}"
                    };
                }
                await _unitOfWork.ProductRepository.SoftRemove(product);
                return new BaseSuccess
                {
                    Message = "Product deleted successfully."
                };
            }
            catch (Exception ex)
            {
                return new BaseError
                {
                    Message = "An error occurred while deleting the product.",
                    Errors = ex.Message
                };
            }
        }

        public async Task<IEnumerable<CommonProductResponse>> GetAllProductAsync()
        {
            try
            {
                var products = await _unitOfWork.ProductRepository.GetAllAsync(include: p => p.Include(p => p.Categories!));
                return _mapper.Map<IEnumerable<CommonProductResponse>>(products);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving products.", ex);
            }
        }

        public async Task<OneOf<CommonProductRequest, BaseError>> GetProductByIdAsync(Guid productId)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(p => p.Id == productId, include: p => p.Include(p => p.Categories!));
                if (product == null)
                {
                    return new BaseError
                    {
                        Message = "Product not found.",
                        Errors = $"No product found with ID: {productId}"
                    };
                }
                return _mapper.Map<CommonProductRequest>(product);
            }
            catch (Exception ex)
            {
                return new BaseError
                {
                    Message = "An error occurred while retrieving the product.",
                    Errors = ex.Message
                };
            }
        }

        public async Task<IEnumerable<CommonProductRequest>> GetProductsByCategoryAsync(Guid categoryId)
        {
            var products = await _unitOfWork.ProductRepository.GetAllAsync(p => p.CategoryId == categoryId, include: p => p.Include(p => p.Categories!));
            return _mapper.Map<IEnumerable<CommonProductRequest>>(products);
        }

        public async Task<OneOf<BaseSuccess, BaseError>> UpdateProductAsync(Guid id, CommonProductRequest updateProductRequest)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(p => p.Id == id);
                if (product == null)
                {
                    return new BaseError
                    {
                        Message = "Product not found.",
                        Errors = $"No product found with ID: {id}"
                    };
                }
                product.UrlImage = updateProductRequest.UrlImage;
                product.Name = updateProductRequest.Name;
                product.CategoryId = updateProductRequest.CategoryId;
                product.Description = updateProductRequest.Description;
                product.Price = updateProductRequest.Price;
                product.StockQuantity = updateProductRequest.StockQuantity;
                _unitOfWork.ProductRepository.Update(product);
                return new BaseSuccess
                {
                    Message = "Product updated successfully."
                };
            }
            catch (Exception ex)
            {
                return new BaseError
                {
                    Message = "An error occurred while updating the product.",
                    Errors = ex.Message
                };
            }
        }
    }
}
