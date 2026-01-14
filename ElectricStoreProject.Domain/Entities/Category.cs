using Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Domain.Entities
{
    public class Category : CommonEntity
    {

        public Guid? CategoryId { get; set; }

        public string? Name { get; set; }

    }
}
