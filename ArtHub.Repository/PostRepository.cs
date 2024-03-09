using ArtHub.BusinessObject;
using ArtHub.DAO;
using ArtHub.DAO.ModelResult;
using ArtHub.Repository.Contracts;

namespace ArtHub.Repository
{
    public class PostRepository : IPostRepository
    {
        public async Task<Post> AddPostAsync(Post post)
            => await PostDAO.Instance.AddPostAsync(post);


        public async Task<Post?> GetPostAsyns(int id)
            => await PostDAO.Instance.GetPost(id);

        public async Task<PagedResult<Post>> GetPostsAsync(QueryPaging queryPaging)
        => await PostDAO.Instance.GetPostsAsync(queryPaging);

        public async Task<IList<Post>> GetPostsByArtistIdAsync(int artistID)
            => await PostDAO.Instance.GetPostsByArtistIdAsync(artistID);

        public async Task<PagedResult<Post>> GetPostsByArtistIdAsync(int artistId, QueryPaging queryPaging)
            => await PostDAO.Instance.GetPostsByArtistIdAsync(artistId, queryPaging);

        public async Task<PagedResult<Post>> GetPostsByArtworkIdAsync(int artworkId, QueryPaging queryPaging)
            => await PostDAO.Instance.GetPostsByArtworkIdAsync(artworkId, queryPaging);

        public async Task<Post?> UpdatePostAsync(int id, Post post)
            => await PostDAO.Instance.UpdatePostAsync(id, post);

        public async Task<bool> DeletePostAsync(int postId)
            => await PostDAO.Instance.DeletePostAsync(postId);

        public async Task<bool> IsExisted(int postId)
            => await PostDAO.Instance.IsExistedPostAsyns(postId);
    }
}
