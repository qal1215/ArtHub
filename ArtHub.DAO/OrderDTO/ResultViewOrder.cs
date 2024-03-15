namespace ArtHub.DTO.OrderDTO
{
    public class ResultViewOrder
    {
        public ViewOrder? ViewOrder { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public string? Message { get; set; }
    }

    public enum OrderStatus
    {
        Success,
        Failed
    }
}
