using ArtHub.BusinessObject;
using ArtHub.DAO;
using ArtHub.Repository.Contracts;

namespace ArtHub.Repository
{
    public class CommentRepository : ICommentRepository
    {
        public async Task<Comment> AddCommentAsync(Comment addComment)
        {
            return await CommentDAO.Instance.AddCommentAsync(addComment);
        }

        public async Task<List<Comment>> GetCommentsByPostId(int postId)
        {
            return await CommentDAO.Instance.GetCommentsByPostId(postId);
        }

        public async Task<Comment?> GetCommentAsync(int commentId)
        {
            return await CommentDAO.Instance.GetCommentById(commentId);
        }

        public Task DeleteCommentAsync(int commentId)
        {
            return CommentDAO.Instance.DeleteCommentAsync(commentId);
        }

        public async Task<Comment?> UpdateCommentAsync(int commentId, Comment addComment)
        {
            return await CommentDAO.Instance.UpdateCommentAsync(commentId, addComment);
        }
    }
}
