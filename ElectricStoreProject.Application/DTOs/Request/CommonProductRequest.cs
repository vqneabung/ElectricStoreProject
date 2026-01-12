using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Application.DTOs.Request
{
    public class CommonProductRequest
    {
        public string? UrlImage { get; set; }

        public string? Name { get; set; }

        public Guid? CategoryId { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

    }
}
