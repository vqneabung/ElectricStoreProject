using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Application.Interface.Repositories
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
        IOrderRepository OrderRepository { get; }
    }
}
