using ElectricStoreProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Application.DTOs.Request
{
    public class CommonOrderDetailRequest
    {
        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

    }
}
