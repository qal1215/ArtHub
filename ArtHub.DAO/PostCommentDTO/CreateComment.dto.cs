namespace ArtHub.DAO.PostCommentDTO
{
    public class CreateComment
    {
        public string Content { get; set; } = null!;

        public int PostId { get; set; }

        public int MemberId { get; set; }
    }
}
