using Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ElectricStoreProject.Domain.Entities
{
    public class OrderDetail : CommonEntity
    {
        public Guid OrderId { get; set; }

        public int Quantity { get; set; }

        public IEnumerable<Product>? Products { get; set; }

        [ForeignKey("OrderId")]
        public Order? Orders { get; set; }

    }
}
