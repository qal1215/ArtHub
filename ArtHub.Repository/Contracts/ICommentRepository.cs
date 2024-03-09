using ArtHub.BusinessObject;

namespace ArtHub.Repository.Contracts
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetCommentsByPostId(int postId);

        Task<Comment> AddCommentAsync(Comment addComment);

        Task<Comment?> GetCommentAsync(int commentId);

        Task<Comment?> UpdateCommentAsync(int commentId, Comment addComment);

        Task DeleteCommentAsync(int commentId);
    }
}
