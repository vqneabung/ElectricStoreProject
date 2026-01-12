using ElectricStoreProject.Application.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public UnitOfWork(IProductRepository productRepository, ICategoryRepository categoryRepository, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public IProductRepository Products => _productRepository;

        public ICategoryRepository Categories => _categoryRepository;

        public IOrderDetailRepository OrderDetails => _orderDetailRepository;

        public IOrderRepository Orders => _orderRepository;
    }
}
