using ArtHub.BusinessObject;

namespace ArtHub.Repository.Contracts
{
    public interface IRatingRepository
    {
        Task<bool> AddRatingForArtwork(Rating rating);

        Task<bool> UnRatingArtwork(Rating rating);

        Task<bool> UpdateRatingForArtwork(Rating rating);

        Task<Rating?> GetRatingByArtworkIdNUserId(int artworkId, int userId);

        Task<List<Rating>> GetRatingsByArtworkId(int artworkId);
    }
}
