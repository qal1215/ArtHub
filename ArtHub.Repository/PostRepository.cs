using ArtHub.BusinessObject;
using ArtHub.DAO.ModelResult;
using ArtHub.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ArtHub.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly ArtHub2024DbContext _dbContext;

        public PostRepository(ArtHub2024DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Post> AddPostAsync(Post post)
        {
            await _dbContext.AddAsync(post);
            await _dbContext.SaveChangesAsync();
            return post;
        }

        public async Task<Post?> GetPostAsyns(int id)
           => await _dbContext.Posts
                .FirstOrDefaultAsync(p => p.PostId == id);

        public async Task<PagedResult<Post>> GetPostsAsync(QueryPaging queryPaging)
        {
            var posts = await _dbContext.Posts
                .OrderBy(p => p.PostId)
                .OrderDescending()
                .Skip((queryPaging.Page - 1) * queryPaging.PageSize)
                .Take(queryPaging.PageSize)
                .ToListAsync();

            var totalPost = await _dbContext.Posts.CountAsync();
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

        public async Task<IList<Post>> GetPostsByArtistIdAsync(int artistId)
            => await _dbContext.Posts
            .Where(p => p.MemberId == artistId)
            .ToListAsync();

        public async Task<PagedResult<Post>> GetPostsByArtistIdAsync(int artistId, QueryPaging queryPaging)
        {
            var posts = await _dbContext.Posts
                .Where(p => p.MemberId == artistId)
                .Skip((queryPaging.Page - 1) * queryPaging.PageSize)
                .Take(queryPaging.PageSize)
                .ToListAsync();

            var totalPost = await _dbContext.Posts.CountAsync(p => p.MemberId == artistId);
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
            var posts = await _dbContext.Posts
                .Where(p => p.ArtworkId == artworkId)
                .Skip((queryPaging.Page - 1) * queryPaging.PageSize)
                .Take(queryPaging.PageSize)
                .ToListAsync();

            var totalPost = await _dbContext.Posts.CountAsync(p => p.ArtworkId == artworkId);
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
            var postToUpdate = await _dbContext.Posts.FirstOrDefaultAsync(p => p.PostId == id);
            if (postToUpdate != null)
            {
                postToUpdate.Title = post.Title;
                postToUpdate.Description = post.Description;
                await _dbContext.SaveChangesAsync();
            }
            return postToUpdate;
        }

        public async Task<bool> DeletePostAsync(int postId)
        {
            var postToDelete = await _dbContext.Posts.FirstOrDefaultAsync(p => p.PostId == postId);
            if (postToDelete is null)
            {
                return false;
            }

            _dbContext.Posts.Remove(postToDelete);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> IsExisted(int postId)
            => await _dbContext.Posts.AnyAsync(p => p.PostId == postId);
    }
}
