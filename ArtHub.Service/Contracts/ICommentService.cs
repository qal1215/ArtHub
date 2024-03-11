using ArtHub.BusinessObject;
using ArtHub.DTO.PostCommentDTO;

namespace ArtHub.Service.Contracts
{
    public interface ICommentService
    {
        Task<ViewComment?> GetCommentById(int commentId);

        Task<IEnumerable<ViewComment>> GetCommentsByPostId(int postId);

        Task<Comment> AddCommentAsync(CreateComment comment);

        Task<Comment?> UpdateCommentAsync(int commentId, UpdateComment comment);

        Task DeleteCommentAsync(int commentId);
    }
}
