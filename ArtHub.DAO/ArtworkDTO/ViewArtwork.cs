namespace ArtHub.DTO.ArtworkDTO
{
    public class ViewArtwork
    {
        public int ArtworkId { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = "";

        public string Image { get; set; } = null!;

        public decimal Price { get; set; }

        public int ArtistID { get; set; }

        public bool IsPublic { get; set; }

        public bool IsBuyAvailable { get; set; }

        public float ArtworkRating { get; set; }

        public DateTime ArtworkDate { get; set; }

        public int GenreId { get; set; }

        public string GenreName { get; set; } = null!;

        public IEnumerable<int> MembersRated { get; set; } = new List<int>();
    }
}
