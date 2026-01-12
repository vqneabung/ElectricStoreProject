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
    public class OrderService : IOrderService
    {

        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OneOf<BaseSuccess, BaseError>> CreateOrderAsync(CreateOrderRequest createOrderRequest)
        {
            try
            {
                await _unitOfWork.OrderRepository.AddAsync(new()
                {
                    CustomerId = createOrderRequest.CustomerId,
                    Status = createOrderRequest.Status,
                    OrderDetails = createOrderRequest.CommonOrderDetailRequest?.ConvertAll(od => new OrderDetail
                    {
                        Quantity = od.Quantity,
                    })
                });
                return new BaseSuccess { Message = "Order created successfully." };
            }
            catch (Exception ex)
            {
                return new BaseError { Message = "An error occurred while creating the order.", Errors = ex.Message };
            }
        }

        public async Task<OneOf<BaseSuccess, BaseError>> DeleteOrderAsync(Guid orderId)
        {
            try
            {
                var order = await _unitOfWork.OrderRepository.GetByIdAsync(o => o.OrderId == orderId);
                if (order == null)
                {
                    return new BaseError { Message = "Order not found." };
                }
                _unitOfWork.OrderRepository.Remove(order);
                return new BaseSuccess { Message = "Order deleted successfully." };
            }
            catch (Exception ex)
            {
                return new BaseError { Message = "An error occurred while deleting the order.", Errors = ex.Message };
            }
        }

        public async Task<IEnumerable<CommonOrderResponse>> GetAllOrderAsync()
        {
            var orders = await _unitOfWork.OrderRepository.GetAllAsync(include: o => o.Include(o => o.OrderDetails!));
            return orders.Select(o => new CommonOrderResponse
            {
                CustomerId = o.CustomerId,
                Status = o.Status,
                OrderDetails = o.OrderDetails?.Select(od => new CommonOrderDetailResponse
                {
                    Quantity = od.Quantity,
                }) ?? new List<CommonOrderDetailResponse>()
            });
        }

        public async Task<OneOf<CommonOrderResponse, BaseError>> GetOrderByIdAsync(Guid orderId)
        {
            try
            {
                var order = await _unitOfWork.OrderRepository.GetByIdAsync(o => o.OrderId == orderId, include: o => o.Include(o => o.OrderDetails!));
                if (order == null)
                {
                    return new BaseError { Message = "Order not found." };
                }
                var orderRequest = new CommonOrderResponse
                {
                    CustomerId = order.CustomerId,
                    Status = order.Status,
                };
                return orderRequest;
            }
            catch (Exception ex)
            {
                return new BaseError { Message = "An error occurred while retrieving the order.", Errors = ex.Message };
            }
        }

        public async Task<IEnumerable<CommonOrderResponse>> GetOrdersByOrderAsync(Guid OrderId)
        {
            var orders = await _unitOfWork.OrderRepository.GetAllAsync(o => o.OrderId == OrderId, include: o => o.Include(o => o.OrderDetails!));
            return orders.Select(o => new CommonOrderResponse
            {
                CustomerId = o.CustomerId,
                Status = o.Status,
            });
        }

        public async Task<OneOf<BaseSuccess, BaseError>> UpdateOrderAsync(Guid id, CommonOrderRequest updateOrderRequest)
        {
            try
            {
                var order = await _unitOfWork.OrderRepository.GetByIdAsync(o => o.OrderId == id);
                if (order == null)
                {
                    return new BaseError { Message = "Order not found." };
                }

                order.CustomerId = updateOrderRequest.CustomerId;
                order.Status = updateOrderRequest.Status;
                _unitOfWork.OrderRepository.Update(order);

                return new BaseSuccess { Message = "Order updated successfully." };

            }
            catch (Exception ex)
            {
                return new BaseError { Message = "An error occurred while updating the order.", Errors = ex.Message };
            }
         }
    }
}
