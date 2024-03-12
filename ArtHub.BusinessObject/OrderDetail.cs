using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtHub.BusinessObject
{
    public class OrderDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; } = null!;

        public int ArtworkId { get; set; }

        public Artwork Artwork { get; set; } = null!;

        public decimal UnitPrice { get; set; }
    }
}
