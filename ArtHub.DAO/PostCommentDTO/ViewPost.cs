namespace ArtHub.DTO.PostCommentDTO
{
    public class ViewPost
    {
        public int PostId { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int MemberId { get; set; }

        public int? ArtworkId { get; set; }

        public IEnumerable<ViewComment> Comments { get; set; } = new List<ViewComment>();
    }
}
