using ArtHub.BusinessObject;
using ArtHub.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ArtHub.Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly ArtHub2024DbContext _dbContext;

        public RatingRepository(ArtHub2024DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> AddRatingForArtwork(Rating rating)
        {
            await _dbContext.Ratings.AddAsync(rating);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UnRatingArtwork(Rating rating)
        {
            _dbContext.Ratings.Remove(rating);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateRatingForArtwork(Rating rating)
        {
            _dbContext.Ratings.Update(rating);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<Rating?> GetRatingByArtworkIdNUserId(int artworkId, int userId)
        {
            var result = await _dbContext.Ratings
                          .Where(r => r.ArtworkId == artworkId && r.MemberId == userId)
                          .FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<Rating>> GetRatingsByArtworkId(int artworkId)
        {
            var result = await _dbContext.Ratings
                           .Where(r => r.ArtworkId == artworkId)
                           .ToListAsync();
            return result;
        }
    }
}
