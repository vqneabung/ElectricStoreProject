using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Domain.Entities
{
    public class OrderDetail
    {
        public Guid OrderDetailId { get; set; }

        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

    }
}
