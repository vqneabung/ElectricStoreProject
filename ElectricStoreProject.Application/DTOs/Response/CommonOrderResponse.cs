using ElectricStoreProject.Domain.Entities;

namespace ElectricStoreProject.Application.DTOs.Response
{
    public class CommonOrderResponse : CommonBaseResponse
    {

        public Guid CustomerId { get; set; }

        public OrderStatus Status { get; set; }

        public IEnumerable<CommonOrderDetailResponse> OrderDetails { get; set; } = new List<CommonOrderDetailResponse>();

    }
}
