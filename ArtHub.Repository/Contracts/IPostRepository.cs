using ArtHub.BusinessObject;

namespace ArtHub.Repository.Contracts
{
    public interface IPostRepository
    {
        Task<Post?> GetPost(int id);
        Task<List<Post>> GetPostsAsync();
        Task<Post> AddPostAsync(Post post);
        Task<List<Post>> GetPostsByArtistAsync(int artistID);
        Task<Post?> UpdatePostAsync(int id, Post post);
        Task<bool> DeletePostAsync(int postId);
        Task<bool> IsExisted(int postId);
    }
}
