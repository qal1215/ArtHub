﻿using System.ComponentModel.DataAnnotations;

namespace ArtHub.DTO.ArtworkDTO
{
    public class CreateArtwork
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string Image { get; set; }

        public decimal Price { get; set; }

        [Required]
        public int ArtistID { get; set; }

        public bool IsPublic { get; set; }

        public bool IsBuyAvailable { get; set; }

        public string GenreName { get; set; } = null!;
    }
}
