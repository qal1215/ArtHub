using ArtHub.DTO.FollowDTO;

namespace ArtHub.Service.Contracts
{
    public interface IFollowService
    {
        Task<bool> FollowArtist(CreateFollow createFollow);
        Task<int> GetFollowersCount(int artistId);
        Task<int> GetFollowingsCount(int followerId);
        Task<IEnumerable<int>> GetListFollowerId(int artistId);
        Task<IEnumerable<int>> GetListFollowingId(int followerId);
        Task<bool> IsFollowed(int followerId, int followeeId);
        Task<bool> UnFollowArtist(CreateFollow createFollow);
    }
}
