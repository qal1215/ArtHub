namespace ArtHub.DTO.PostCommentDTO
{
    public class ViewComment
    {
        public int CommentId { get; set; }

        public string Content { get; set; } = null!;

        public int PostId { get; set; }

        public int MemberId { get; set; }

        public string MemberName { get; set; } = null!;

        public string? MemberAvatar { get; set; }
    }
}
