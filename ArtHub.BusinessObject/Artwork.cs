using System.ComponentModel.DataAnnotations.Schema;

namespace ArtHub.BusinessObject
{
    public class Artwork
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArtworkID { get; set; }

        public string ArtworkName { get; set; }

        public string ArtworkDescription { get; set; }

        public string ArtworkImage { get; set; }

        public decimal ArtworkPrice { get; set; }

        public int ArtistID { get; set; }

        public Member Artist { get; set; } = null!;

        public bool IsPublic { get; set; }

        public bool IsBuyAvailable { get; set; }

        public DateTime ArtworkDate { get; set; }
    }
}
