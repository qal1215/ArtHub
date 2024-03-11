using ArtHub.BusinessObject;
using ArtHub.DTO.ModelResult;

namespace ArtHub.Repository.Contracts
{
    public interface IPostRepository
    {
        Task<Post> AddPostAsync(Post post);

        Task<Post?> GetPostAsyns(int id);

        Task<PagedResult<Post>> GetPostsAsync(QueryPaging queryPaging);

        Task<IList<Post>> GetPostsByArtistIdAsync(int artistID);

        Task<PagedResult<Post>> GetPostsByArtistIdAsync(int artistID, QueryPaging queryPaging);

        Task<PagedResult<Post>> GetPostsByArtworkIdAsync(int artworkId, QueryPaging queryPaging);

        Task<Post?> UpdatePostAsync(int id, Post post);

        Task<bool> DeletePostAsync(int postId);

        Task<bool> IsExisted(int postId);
    }
}
