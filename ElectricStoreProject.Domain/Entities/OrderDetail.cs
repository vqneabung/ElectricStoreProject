using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Domain.Entities
{
    public class OrderDetail
    {
        public Guid OrderDetailId { get; set; }

        public Guid OrderId { get; set; }

        public int Quantity { get; set; }

        public IEnumerable<Product>? Products { get; set; }

        public Order? Orders { get; set; }

    }
}
