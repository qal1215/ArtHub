﻿using System.ComponentModel.DataAnnotations;

namespace ArtHub.DTO.ReportDTO
{
    public class UpdateReport
    {
        [Required]
        public int ReportId { get; set; }

        [Required]
        public string ReportDescription { get; set; } = null!;

        [Required]
        public bool IsResolved { get; set; }

    }
}
