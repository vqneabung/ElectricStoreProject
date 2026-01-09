using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Domain.Entities
{
    public class Order
    {
        public Guid OrderId { get; set; }

        public Guid CustomerId { get; set; }

        public OrderStatus Status { get; set; }

    }

    public enum OrderStatus
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }
}
