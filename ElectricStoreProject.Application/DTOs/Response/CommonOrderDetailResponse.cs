namespace ElectricStoreProject.Application.DTOs.Response
{
    public class CommonOrderDetailResponse : CommonBaseResponse
    {

        public Guid OrderId { get; set; }

        public int Quantity { get; set; }

    }

}
