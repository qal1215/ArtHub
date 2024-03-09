using ArtHub.BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace ArtHub.DAO
{
    public class PostDAO
    {
        private static PostDAO instance = null;
        private readonly ArtHub2024DbContext dbContext = null;
        public PostDAO()
        {
            if (dbContext == null)
            {
                dbContext = new ArtHub2024DbContext();
            }
        }

        public static PostDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PostDAO();
                }
                return instance;
            }
        }

        public async Task<Post?> GetPost(int id)
        {
            var post = await dbContext.Posts
                .Where(p => p.PostId == id)
                .FirstOrDefaultAsync();

            return post;
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            return await dbContext.Posts.ToListAsync();
        }

        public async Task<Post> AddPostAsync(Post post)
        {
            await dbContext.AddAsync(post);
            await dbContext.SaveChangesAsync();
            return post;
        }

        public async Task<List<Post>> GetPostsByArtistAsync(int artistID)
        {
            return await dbContext.Posts.Where(p => p.MemberId == artistID).ToListAsync();
        }

        public async Task<Post?> UpdatePostAsync(int id, Post post)
        {
            var postToUpdate = await dbContext.Posts.FirstOrDefaultAsync(p => p.PostId == id);
            if (postToUpdate != null)
            {
                postToUpdate.Title = post.Title;
                postToUpdate.Description = post.Description;
                await dbContext.SaveChangesAsync();
            }
            return postToUpdate;
        }

        public async Task<bool> DeletePostAsync(int id)
        {
            var postToDelete = await dbContext.Posts.FirstOrDefaultAsync(p => p.PostId == id);
            if (postToDelete != null)
            {
                dbContext.Posts.Remove(postToDelete);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> IsExistedPostAsyns(int postId)
            => await dbContext.Posts.AnyAsync(p => p.PostId == postId);
    }
}
