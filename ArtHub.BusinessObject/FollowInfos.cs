using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtHub.BusinessObject
{
    public class FollowInfos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int FollowInfoId { get; set; }

        public int FolloweeId { get; set; }

        public Member Followee { get; set; }

        public int FollowerId { get; set; }

        public Member Follower { get; set; }
    }
}
