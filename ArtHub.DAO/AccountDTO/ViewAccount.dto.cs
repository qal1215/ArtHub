using ArtHub.BusinessObject;

namespace ArtHub.DAO.AccountDTO
{
    public class ViewAccount
    {
        public int AccountId { get; set; }

        public string FullName { get; set; } = null!;

        public string? EmailAddress { get; set; }

        public string? Avatar { get; set; }

        public Role? Role { get; set; }

        public virtual ICollection<Artwork> Artworks { get; set; } = new HashSet<Artwork>();
    }
}
