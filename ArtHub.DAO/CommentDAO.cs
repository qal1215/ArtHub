using ArtHub.BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace ArtHub.DAO
{
    public class CommentDAO
    {
        private static CommentDAO instance = null;

        private readonly ArtHub2024DbContext dbContext = null;

        public CommentDAO()
        {
            if (dbContext == null)
            {
                dbContext = new ArtHub2024DbContext();
            }
        }

        public static CommentDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommentDAO();
                }
                return instance;
            }
        }

        public async Task<Comment?> GetCommentByPostId(int postId)
        {
            return await dbContext.Comments.FirstOrDefaultAsync(c => c.PostId == postId);
        }

        public async Task<List<Comment>> GetCommentsByPostId(int postId)
        {
            return await dbContext.Comments.Where(c => c.PostId == postId).ToListAsync();
        }

        public async Task<Comment> AddCommentAsync(Comment comment)
        {
            await dbContext.AddAsync(comment);
            await dbContext.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment?> GetCommentById(int commentId)
        {
            return await dbContext.Comments.FirstOrDefaultAsync(c => c.CommentId == commentId);
        }

        public async Task DeleteCommentAsync(int commentId)
        {
            var comment = await dbContext.Comments.FirstOrDefaultAsync(c => c.CommentId == commentId);

            dbContext.Comments.Remove(comment!);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Comment?> UpdateCommentAsync(int commentId, Comment comment)
        {
            var commentToUpdate = await dbContext.Comments.FirstOrDefaultAsync(c => c.CommentId == commentId);
            if (commentToUpdate != null)
            {
                commentToUpdate.Content = comment.Content;
                await dbContext.SaveChangesAsync();
            }
            return commentToUpdate;
        }
    }
}
