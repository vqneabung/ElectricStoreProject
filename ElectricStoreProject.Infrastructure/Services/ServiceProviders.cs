using ElectricStoreProject.Application.Interface.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Infrastructure.Services
{
    public class ServiceProviders : IServiceProviders
    {

        private readonly ICategoryService _categoryService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public ServiceProviders(ICategoryService categoryService, IOrderDetailService orderDetailService, IProductService productService, IOrderService orderService)
        {
            _categoryService = categoryService;
            _orderDetailService = orderDetailService;
            _productService = productService;
            _orderService = orderService;
        }

        public ICategoryService CategoryService => _categoryService;

        public IOrderDetailService OrderDetailService => _orderDetailService;

        public IProductService ProductService => _productService;

        public IOrderService OrderService => _orderService;

    }
}
