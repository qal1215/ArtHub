using ArtHub.BusinessObject;
using ArtHub.DAO;
using ArtHub.Repository.Contracts;

namespace ArtHub.Repository
{
    public class RatingRepository : IRatingRepository
    {
        public async Task<bool> AddRatingForArtwork(Rating rating)
        {
            return await RatingDAO.Instance.AddRating(rating);
        }

        public async Task<bool> UnRatingArtwork(Rating rating)
        {
            return await RatingDAO.Instance.Unrating(rating);
        }

        public async Task<bool> UpdateRatingForArtwork(Rating rating)
        {
            return await RatingDAO.Instance.UpdateRating(rating);
        }

        public async Task<Rating?> GetRatingByArtworkIdNUserId(int artworkId, int userId)
        {
            return await RatingDAO.Instance.GetRatingByArtworkIdNUserId(artworkId, userId);
        }

        public async Task<List<Rating>> GetRatingsByArtworkId(int artworkId)
        {
            return await RatingDAO.Instance.GetRatingsByArtworkId(artworkId);
        }
    }
}
