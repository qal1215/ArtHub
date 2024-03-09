namespace ArtHub.DAO.PostCommentDTO
{
    public class UpdatePost
    {
        public int PostId { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
