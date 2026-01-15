using AutoMapper;
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
        private readonly IMapper _mapper;

        public OrderDetailService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OneOf<BaseSuccess, BaseError>> CreateOrderDetailAsync(CreateOrderDetailRequest createBlogRequest)
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
                var orderDetail = await _unitOfWork.OrderDetailRepository.GetByIdAsync(od => od.Id == orderDetailId);
                if (orderDetail == null)
                {
                    return new BaseError { Message = "Order detail not found." };
                }
                await _unitOfWork.OrderDetailRepository.SoftRemove(orderDetail);
                return new BaseSuccess { Message = "Order detail deleted successfully." };
            }
            catch (Exception ex)
            {
                return new BaseError { Message = "An error occurred while deleting the order detail.", Errors = ex.Message };
            }
        }

        public async Task<IEnumerable<CommonOrderDetailResponse>> GetAllOrderDetailAsync()
        {
            var orderDetails = await _unitOfWork.OrderDetailRepository.GetAllAsync(od => od.IsActive == true);

            return _mapper.Map<IEnumerable<CommonOrderDetailResponse>>(orderDetails);
        }

        public async Task<OneOf<CommonOrderDetailResponse, BaseError>> GetOrderDetailByIdAsync(Guid orderDetailId)
        {
            try
            {
                var orderDetail = await _unitOfWork.OrderDetailRepository.GetByIdAsync(od => od.Id == orderDetailId && od.IsActive == true);
                if (orderDetail == null)
                {
                    return new BaseError { Message = "Order detail not found." };
                }
                return _mapper.Map<CommonOrderDetailResponse>(orderDetail);
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
                var orderDetail = await _unitOfWork.OrderDetailRepository.GetByIdAsync(od => od.Id == id && od.IsActive == true);
                if (orderDetail == null)
                {
                    return new BaseError { Message = "Order detail not found." };
                }
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
