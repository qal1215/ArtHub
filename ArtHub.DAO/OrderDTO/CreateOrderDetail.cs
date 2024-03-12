using System.ComponentModel.DataAnnotations;

namespace ArtHub.DTO.OrderDTO
{
    public class CreateOrderDetail
    {
        [Required]
        public int ArtworkId { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }
    }
}
