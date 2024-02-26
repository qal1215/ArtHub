using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtHub.BusinessObject
{
    public class Rating
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int RatingId { get; set; }

        public int ArtworkId { get; set; }

        public Artwork Artwork { get; set; } = null!;

        public int MemberId { get; set; }

        public Member Member { get; set; } = null!;

        public int Rate { get; set; }
    }
}
