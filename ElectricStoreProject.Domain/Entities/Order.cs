using Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Domain.Entities
{
    public class Order : CommonEntity
    {

        public Guid CustomerId { get; set; }

        public OrderStatus Status { get; set; }

        public IEnumerable<OrderDetail>? OrderDetails { get; set; } = new List<OrderDetail>();

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
