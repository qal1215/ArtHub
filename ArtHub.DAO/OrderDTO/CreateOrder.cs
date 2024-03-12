namespace ArtHub.DTO.OrderDTO
{
    public class CreateOrder
    {
        public int BuyerId { get; set; }

        public int TotalQuantity { get; set; }

        public decimal TotalAmount { get; set; }

        public ICollection<CreateOrderDetail> OrderDetails { get; set; } = new List<CreateOrderDetail>();
    }
}
