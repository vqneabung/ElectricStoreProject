using Common.Repository;
using ElectricStoreProject.Application.Interface.Repositories;
using ElectricStoreProject.Domain.Entities;
using ElectricStoreProject.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Infrastructure.Repositories
{
    public class OrderDetailRepository : GenericRepositoryWithContext<ElectricStoreDBContext, OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(ElectricStoreDBContext context) : base(context)
        {
        }
    }

}
