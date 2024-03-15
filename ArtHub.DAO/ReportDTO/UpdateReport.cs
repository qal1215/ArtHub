using System.ComponentModel.DataAnnotations;

namespace ArtHub.DTO.ReportDTO
{
    public class UpdateReport
    {
        [Required]
        public int ReportId { get; set; }

        [Required]
        public string? ResolveDescription { get; set; }

        [Required]
        public bool IsResolved { get; set; }

        [Required]
        public bool IsBanArtwork { get; set; }

    }
}
