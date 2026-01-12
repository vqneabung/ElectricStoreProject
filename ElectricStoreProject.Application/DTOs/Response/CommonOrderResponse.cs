using ElectricStoreProject.Domain.Entities;

namespace ElectricStoreProject.Application.DTOs.Response
{
    public class CommonOrderResponse
    {
        public Guid OrderId { get; set; }

        public Guid CustomerId { get; set; }

        public OrderStatus Status { get; set; }

        public IEnumerable<CommonOrderDetailResponse> OrderDetails { get; set; } = new List<CommonOrderDetailResponse>();

    }
}
