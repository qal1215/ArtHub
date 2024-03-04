namespace ArtHub.BusinessObject
{
    public class OrderDetail
    {
        public Order Order { get; set; } = null!;

        public Artwork Artwork { get; set; } = null!;

        public decimal UnitPrice { get; set; }
    }
}
