using Common.Repository;
using ElectricStoreProject.Application.Interface.Repositories;
using ElectricStoreProject.Domain.Entities;
using ElectricStoreProject.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepositoryWithContext<ElectricStoreDBContext, Product>, IProductRepository
    {
        public ProductRepository(ElectricStoreDBContext context) : base(context)
        {
        }
    }
}
