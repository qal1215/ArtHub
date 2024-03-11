using ArtHub.BusinessObject;
using ArtHub.DTO.ArtworkDTO;

namespace ArtHub.DTO.AccountDTO
{
    public class ViewAccount
    {
        public int AccountId { get; set; }

        public string FullName { get; set; } = null!;

        public string? EmailAddress { get; set; }

        public string? Avatar { get; set; }

        public Role? Role { get; set; }

        public IEnumerable<ViewArtwork> ViewArtworks { get; set; } = new List<ViewArtwork>();
    }
}
