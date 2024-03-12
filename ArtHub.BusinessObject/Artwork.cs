using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtHub.BusinessObject
{
    public class Artwork
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ArtworkId { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; }

        public string Image { get; set; } = null!;

        public decimal Price { get; set; }

        public int ArtistID { get; set; }

        public Member Artist { get; set; } = null!;

        public bool IsPublic { get; set; }

        public bool IsBuyAvailable { get; set; }

        public float ArtworkRating { get; set; }

        public DateTime ArtworkDate { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; } = null!;
    }
}
