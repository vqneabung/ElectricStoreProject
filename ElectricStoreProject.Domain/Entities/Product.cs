using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Domain.Entities
{
    public class Product
    {
        public Guid ProductId { get; set; }

        public string? UrlImage { get; set; }

        public string? Name { get; set; }

        public string? Category { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime LastUpdatedAt { get; set; }

        public bool IsActive { get; set; }

    }
}
