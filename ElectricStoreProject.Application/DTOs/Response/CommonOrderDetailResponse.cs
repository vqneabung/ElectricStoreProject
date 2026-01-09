namespace ElectricStoreProject.Application.DTOs.Response
{
    public class CommonOrderDetailResponse
    {
        public Guid OrderDetailId { get; set; }

        public Guid OrderId { get; set; }

        public int Quantity { get; set; }

    }

}
