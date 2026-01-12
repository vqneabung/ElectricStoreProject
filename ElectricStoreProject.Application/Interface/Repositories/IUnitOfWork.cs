using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Application.Interface.Repositories
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        IOrderDetailRepository OrderDetails { get; }
        IOrderRepository Orders { get; }
    }
}
