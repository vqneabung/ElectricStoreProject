using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricStoreProject.Application.DTOs.Request
{
    public class CreateOrderRequest : CommonOrderRequest
    {
        public List<CommonOrderDetailRequest>? CommonOrderDetailRequest { get; set; }
    }
}
