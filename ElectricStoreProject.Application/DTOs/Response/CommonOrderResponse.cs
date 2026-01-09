using ElectricStoreProject.Domain.Entities;

namespace ElectricStoreProject.Application.DTOs.Response
{
    public class CommonOrderResponse
    {
        public Guid OrderId { get; set; }

        public Guid CustomerId { get; set; }

        public OrderStatus Status { get; set; }

    }
}
