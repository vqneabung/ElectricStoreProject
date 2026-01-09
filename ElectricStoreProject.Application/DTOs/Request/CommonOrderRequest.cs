using ElectricStoreProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Application.DTOs.Request
{
    public class CommonOrderRequest
    {

        public Guid CustomerId { get; set; }

        public OrderStatus Status { get; set; }

    }
}
