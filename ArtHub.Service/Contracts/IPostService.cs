using ArtHub.BusinessObject;
using ArtHub.DTO.ModelResult;
using ArtHub.DTO.PostCommentDTO;

namespace ArtHub.Service.Contracts
{
    public interface IPostService
    {
        Task<Post> AddPostAsync(CreatePost post);

        Task<List<ViewPost>?> GetListPostAsync();

        Task<ViewPost?> GetPostAsync(int postId);

        Task<Post?> UpdatePostAsync(int postId, UpdatePost post);

        Task<bool> DeletePostAsync(int postId);

        Task<bool> IsExisted(int postId);

        Task<PagedResult<ViewPost>> GetPostByUserId(int userId, QueryPaging queryPaging);

        Task<PagedResult<ViewPost>> GetPostByArtworkId(int artworkId, QueryPaging queryPaging);

    }
}
