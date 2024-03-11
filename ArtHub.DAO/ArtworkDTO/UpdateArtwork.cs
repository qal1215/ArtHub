using System.ComponentModel.DataAnnotations;

namespace ArtHub.DTO.ArtworkDTO
{
    public class UpdateArtwork
    {
        [Required]
        public int ArtworkId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string Image { get; set; }

        public decimal Price { get; set; }

        public bool IsPublic { get; set; }

        public bool IsBuyAvailable { get; set; }
    }
}
