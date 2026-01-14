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

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OneOf<BaseSuccess, BaseError>> CreateProductAsync(CommonProductRequest createProductRequest)
        {
            try
            {
                await _unitOfWork.ProductRepository.AddAsync(new Product
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
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(p => p.ProductId == productId);
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
                return products.Select(p => new CommonProductResponse
                {
                    UrlImage = p.UrlImage,
                    Name = p.Name,
                    CategoryId = p.Categories!.CategoryId,
                    Description = p.Description,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity
                }).ToList();
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
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(p => p.ProductId == productId, include: p => p.Include(p => p.Categories!));
                if (product == null)
                {
                    return new BaseError
                    {
                        Message = "Product not found.",
                        Errors = $"No product found with ID: {productId}"
                    };
                }
                return new CommonProductRequest
                {
                    UrlImage = product.UrlImage,
                    Name = product.Name,
                    CategoryId = product.Categories!.CategoryId,
                    Description = product.Description,
                    Price = product.Price,
                    StockQuantity = product.StockQuantity
                };
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
            return products.Select(p => new CommonProductRequest
            {
                UrlImage = p.UrlImage,
                Name = p.Name,
                CategoryId = p.Categories!.CategoryId,
                Description = p.Description,
                Price = p.Price,
                StockQuantity = p.StockQuantity
            }).ToList();
        }

        public async Task<OneOf<BaseSuccess, BaseError>> UpdateProductAsync(Guid id, CommonProductRequest updateProductRequest)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(p => p.ProductId == id);
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
