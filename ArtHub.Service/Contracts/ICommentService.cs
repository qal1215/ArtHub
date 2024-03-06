using ArtHub.BusinessObject;
using ArtHub.DAO.PostCommentDTO;

namespace ArtHub.Service.Contracts
{
    public interface ICommentService
    {
        Task<Comment?> GetCommentById(int commentId);
        Task<List<Comment>> GetCommentsByPostId(int postId);
        Task<Comment> AddCommentAsync(CreateComment comment);
    }
}
