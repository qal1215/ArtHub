using ArtHub.BusinessObject;
using ArtHub.DAO;
using ArtHub.Repository.Contracts;

namespace ArtHub.Repository
{
    public class PostRepository : IPostRepository
    {
        public async Task<Post> AddPostAsync(Post post)
            => await PostDAO.Instance.AddPostAsync(post);


        public async Task<Post?> GetPost(int id)
            => await PostDAO.Instance.GetPost(id);

        public Task<List<Post>> GetPostsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Post>> GetPostsByArtistAsync(int artistID)
            => await PostDAO.Instance.GetPostsByArtistAsync(artistID);

        public async Task<Post?> UpdatePostAsync(int id, Post post)
            => await PostDAO.Instance.UpdatePostAsync(id, post);

        public async Task<bool> DeletePostAsync(int postId)
            => await PostDAO.Instance.DeletePostAsync(postId);

        public async Task<bool> IsExisted(int postId)
            => await PostDAO.Instance.IsExistedPostAsyns(postId);
    }
}
