using ArtHub.BusinessObject;
using ArtHub.DAO.ModelResult;
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

        public async Task<PagedResult<Post>> GetPostsAsync(QueryPaging queryPaging)
        {
            var posts = await dbContext.Posts
                .OrderBy(p => p.PostId)
                .OrderDescending()
                .Skip((queryPaging.Page - 1) * queryPaging.PageSize)
                .Take(queryPaging.PageSize)
                .ToListAsync();

            var totalPost = await dbContext.Posts.CountAsync();
            var totalPages = (int)Math.Ceiling(totalPost / (double)queryPaging.PageSize);

            return new PagedResult<Post>
            {
                Items = posts,
                Page = queryPaging.Page,
                PageSize = queryPaging.PageSize,
                TotalItems = totalPost,
                TotalPages = totalPages
            };
        }

        public async Task<Post> AddPostAsync(Post post)
        {
            await dbContext.AddAsync(post);
            await dbContext.SaveChangesAsync();
            return post;
        }

        public async Task<IList<Post>> GetPostsByArtistIdAsync(int artistId)
            => await dbContext.Posts.Where(p => p.MemberId == artistId).ToListAsync();

        public async Task<PagedResult<Post>> GetPostsByArtistIdAsync(int artistId, QueryPaging queryPaging)
        {
            var posts = await dbContext.Posts
                .Where(p => p.MemberId == artistId)
                .Skip((queryPaging.Page - 1) * queryPaging.PageSize)
                .Take(queryPaging.PageSize)
                .ToListAsync();

            var totalPost = await dbContext.Posts.CountAsync(p => p.MemberId == artistId);
            var totalPages = (int)Math.Ceiling(totalPost / (double)queryPaging.PageSize);

            return new PagedResult<Post>
            {
                Items = posts,
                Page = queryPaging.Page,
                PageSize = queryPaging.PageSize,
                TotalItems = totalPost,
                TotalPages = totalPages
            };
        }

        public async Task<PagedResult<Post>> GetPostsByArtworkIdAsync(int artworkId, QueryPaging queryPaging)
        {
            var posts = await dbContext.Posts
                .Where(p => p.ArtworkId == artworkId)
                .Skip((queryPaging.Page - 1) * queryPaging.PageSize)
                .Take(queryPaging.PageSize)
                .ToListAsync();

            var totalPost = await dbContext.Posts.CountAsync(p => p.ArtworkId == artworkId);
            var totalPages = (int)Math.Ceiling(totalPost / (double)queryPaging.PageSize);

            return new PagedResult<Post>
            {
                Items = posts,
                Page = queryPaging.Page,
                PageSize = queryPaging.PageSize,
                TotalItems = totalPost,
                TotalPages = totalPages
            };
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
