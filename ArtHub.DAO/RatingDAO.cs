using ArtHub.BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace ArtHub.DAO
{
    public class RatingDAO
    {
        private static RatingDAO instance = null;
        private readonly ArtHub2024DbContext dbContext = null;
        public RatingDAO()
        {
            if (dbContext == null)
            {
                dbContext = new ArtHub2024DbContext();
            }
        }

        public static RatingDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RatingDAO();
                }
                return instance;
            }
        }

        public async Task<bool> AddRating(Rating rating)
        {
            await dbContext.Ratings.AddAsync(rating);
            var result = await dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> Unrating(Rating rating)
        {
            dbContext.Ratings.Remove(rating);
            var result = await dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateRating(Rating rating)
        {
            dbContext.Ratings.Update(rating);
            var result = await dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<Rating?> GetRatingByArtworkIdNUserId(int artworkId, int userId)
        {
            var result = await dbContext.Ratings
               .Where(r => r.ArtworkId == artworkId && r.MemberId == userId)
               .FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<Rating>> GetRatingsByArtworkId(int artworkId)
        {
            var result = await dbContext.Ratings
               .Where(r => r.ArtworkId == artworkId)
               .ToListAsync();
            return result;
        }
    }
}
