using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtHub.BusinessObject
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int OrderId { get; set; }

        public int BuyerId { get; set; }

        public Member Buyer { get; set; } = null!;

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public int TotalQuantity { get; set; }

        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
