namespace ArtHub.DTO.OrderDTO
{
    public class ViewOrder
    {
        public int OrderId { get; set; }

        public int BuyerId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public int TotalQuantity { get; set; }

        public virtual IEnumerable<ViewOrderDetail> OrderDetails { get; set; } = new List<ViewOrderDetail>();
    }
}
