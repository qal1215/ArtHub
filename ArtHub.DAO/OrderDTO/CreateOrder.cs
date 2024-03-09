using System.ComponentModel.DataAnnotations;

namespace ArtHub.DAO.OrderDTO
{
    public class CreateOrder
    {
        [Required]
        public int BuyerId {  get; set; }
        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public int TotalQuantity { get; set; }
    }
}
