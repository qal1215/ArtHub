using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtHub.BusinessObject;

public partial class Member
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int AccountId { get; set; }

    public string Password { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string? EmailAddress { get; set; }

    public string? Avatar { get; set; }

    public int? Role { get; set; }

    public virtual ICollection<Artwork> Artworks { get; set; } = new HashSet<Artwork>();
}
