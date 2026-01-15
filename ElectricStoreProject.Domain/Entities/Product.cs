using Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ElectricStoreProject.Domain.Entities
{
    public class Product : CommonEntity
    {
        public string? UrlImage { get; set; }

        public string? Name { get; set; }

        public Guid? CategoryId { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category? Categories { get; set; }

    }
}
