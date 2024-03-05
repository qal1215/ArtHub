using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtHub.BusinessObject
{
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int PostId { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Image { get; set; } = null!;

        public int MemberId { get; set; }

        public Member Member { get; set; } = null!;

        public int? ArtworkId { get; set; }

        public Artwork? Artwork { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
