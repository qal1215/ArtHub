using ArtHub.BusinessObject;

namespace ArtHub.Repository
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetCommentsByPostId(int postId);
        Task<Comment> AddCommentAsync(Comment addComment);
        Task<Comment?> GetCommentAsync(int commentId);
    }
}
