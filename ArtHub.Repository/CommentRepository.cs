using ArtHub.BusinessObject;
using ArtHub.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ArtHub.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ArtHub2024DbContext _dbContext;

        public CommentRepository(ArtHub2024DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Comment> AddCommentAsync(Comment addComment)
        {
            await _dbContext.AddAsync(addComment);
            await _dbContext.SaveChangesAsync();
            return addComment;
        }

        public async Task<List<Comment>> GetCommentsByPostId(int postId)
        {
            return await _dbContext.Comments.Where(c => c.PostId == postId).ToListAsync();
        }

        public async Task<Comment?> GetCommentAsync(int commentId)
        {
            return await _dbContext.Comments.FirstOrDefaultAsync(c => c.CommentId == commentId);
        }

        public async Task DeleteCommentAsync(int commentId)
        {
            var comment = await _dbContext.Comments.FirstOrDefaultAsync(c => c.CommentId == commentId);

            _dbContext.Comments.Remove(comment!);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Comment?> UpdateCommentAsync(int commentId, Comment updateComment)
        {
            var commentToUpdate = await _dbContext.Comments.FirstOrDefaultAsync(c => c.CommentId == commentId);
            if (commentToUpdate != null)
            {
                commentToUpdate.Content = updateComment.Content;
                await _dbContext.SaveChangesAsync();
            }

            return commentToUpdate;
        }
    }
}
