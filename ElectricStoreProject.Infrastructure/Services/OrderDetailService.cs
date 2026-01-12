using Common;
using ElectricStoreProject.Application.DTOs.Request;
using ElectricStoreProject.Application.DTOs.Response;
using ElectricStoreProject.Application.Interface.Repositories;
using ElectricStoreProject.Application.Interface.Services;
using ElectricStoreProject.Domain.Entities;
using OneOf;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Infrastructure.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OneOf<BaseSuccess, BaseError>> CreateOrderDetailAsync(CommonOrderDetailRequest createBlogRequest)
        {
            try
            {
                await _unitOfWork.OrderDetailRepository.AddAsync(new()
                {
                    OrderId = createBlogRequest.OrderId,
                    Quantity = createBlogRequest.Quantity
                });

                return new BaseSuccess { Message = "Order detail created successfully." };
            }
            catch (Exception ex)
            {
                return new BaseError { Message = "An error occurred while creating the order detail.", Errors = ex.Message };
            }
        }

        public async Task<OneOf<BaseSuccess, BaseError>> DeleteOrderDetailAsync(Guid orderDetailId)
        {
            try
            {
                var orderDetail = await _unitOfWork.OrderDetailRepository.GetByIdAsync(od => od.OrderDetailId == orderDetailId);
                if (orderDetail == null)
                {
                    return new BaseError { Message = "Order detail not found." };
                }
                _unitOfWork.OrderDetailRepository.Remove(orderDetail);
                return new BaseSuccess { Message = "Order detail deleted successfully." };
            }
            catch (Exception ex)
            {
                return new BaseError { Message = "An error occurred while deleting the order detail.", Errors = ex.Message };
            }
        }

        public async Task<IEnumerable<CommonOrderDetailResponse>> GetAllOrderDetailAsync()
        {
            var orderDetails = await _unitOfWork.OrderDetailRepository.GetAllAsync();

            return [..orderDetails.Select(od => new CommonOrderDetailResponse{
                OrderId = od.OrderId,
                Quantity = od.Quantity
            })];
        }

        public async Task<OneOf<CommonOrderDetailResponse, BaseError>> GetOrderDetailByIdAsync(Guid OrderDetailId)
        {
            try
            {
                var orderDetail = await _unitOfWork.OrderDetailRepository.GetByIdAsync(od => od.OrderDetailId == OrderDetailId);
                if (orderDetail == null)
                {
                    return new BaseError { Message = "Order detail not found." };
                }
                return new CommonOrderDetailResponse
                {
                    OrderId = orderDetail.OrderId,
                    Quantity = orderDetail.Quantity
                };
            }
            catch (Exception ex)
            {
                return new BaseError { Message = "An error occurred while retrieving the order detail.", Errors = ex.Message };
            }
        }

        public async Task<OneOf<BaseSuccess, BaseError>> UpdateOrderDetailAsync(Guid id, CommonOrderDetailRequest updateBlogRequest)
        {
            try
            {
                var orderDetail = await _unitOfWork.OrderDetailRepository.GetByIdAsync(od => od.OrderDetailId == id);
                if (orderDetail == null)
                {
                    return new BaseError { Message = "Order detail not found." };
                }
                orderDetail.OrderId = updateBlogRequest.OrderId;
                orderDetail.Quantity = updateBlogRequest.Quantity;
                _unitOfWork.OrderDetailRepository.Update(orderDetail);
                return new BaseSuccess { Message = "Order detail updated successfully." };
            }
            catch (Exception ex
            )
            {
                return new BaseError { Message = "An error occurred while updating the order detail.", Errors = ex.Message };
            }
        }
    }
}
