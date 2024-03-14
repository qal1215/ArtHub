using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtHub.BusinessObject
{
    public class Report
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReportId { get; set; }

        public string ReportReason { get; set; } = null!;

        public string ResolveDescription { get; set; } = null!;

        public bool IsResolved { get; set; }

        public int ArtworkId { get; set; }

        public Artwork Artwork { get; set; } = null!;

        public int ReporterId { get; set; }

        public Member Reporter { get; set; } = null!;
    }
}
