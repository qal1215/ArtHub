using ArtHub.BusinessObject;
using ArtHub.DAO.PostCommentDTO;

namespace ArtHub.Service.Contracts
{
    public interface IPostService
    {
        Task<Post> AddPostAsync(CreatePost post);
        Task<List<Post>?> GetPostsAsync();
        Task<Post?> GetPostAsync(int postId);
        Task<Post?> UpdatePostAsync(int postId, UpdatePost post);
        Task<bool> DeletePostAsync(int postId);
    }
}
