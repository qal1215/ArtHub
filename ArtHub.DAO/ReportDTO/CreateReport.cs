using System.ComponentModel.DataAnnotations;

namespace ArtHub.DTO.ReportDTO
{
    public class CreateReport
    {
        [Required]
        public string ReportReason { get; set; } = null!;

        public int ArtworkId { get; set; }

        public int ReporterId { get; set; }
    }
}
