using Common.Repository;
using ElectricStoreProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Application.Interface.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
    }
}
