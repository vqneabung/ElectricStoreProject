using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Application.DTOs.Request
{
    public class CreateOrderDetailRequest : CommonOrderDetailRequest
    {
        public Guid OrderId { get; set; }
    }
}
