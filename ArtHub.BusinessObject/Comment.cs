using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtHub.BusinessObject
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CommentId { get; set; }

        public string Content { get; set; } = null!;

        public int PostId { get; set; }

        public Post Post { get; set; } = null!;

        public int MemberId { get; set; }

        public Member Member { get; set; } = null!;
    }
}
