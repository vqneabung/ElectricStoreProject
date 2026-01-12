using Common.Repository;
using ElectricStoreProject.Domain.Entities;
using ElectricStoreProject.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepositoryWithContext<ElectricStoreDBContext, Order>, Application.Interface.Repositories.IOrderRepository
    {
        public OrderRepository(ElectricStoreDBContext context) : base(context)
        {
        }
    }
}
