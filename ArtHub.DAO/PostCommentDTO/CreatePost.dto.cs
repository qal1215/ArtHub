namespace ArtHub.DAO.PostCommentDTO
{
    public class CreatePost
    {
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int MemberId { get; set; }

        public int ArtworkId { get; set; }
    }
}
