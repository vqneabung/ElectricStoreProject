using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Application.Interface.Services
{
    public interface IServiceProviders
    {
        public ICategoryService CategoryService { get; }
        public IOrderDetailService OrderDetailService { get; }
        public IProductService ProductService { get; }
        public IOrderService OrderService { get; }

    }
}
