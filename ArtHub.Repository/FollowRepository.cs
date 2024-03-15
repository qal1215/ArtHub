using ArtHub.BusinessObject;
using ArtHub.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ArtHub.Repository
{
    public class FollowRepository : IFollowRepository
    {
        private readonly ArtHub2024DbContext _dbContext;

        public FollowRepository(ArtHub2024DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> FollowArtist(FollowInfos follow)
        {
            await _dbContext.FollowInfos.AddAsync(follow);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<IEnumerable<int>> GetListFollowerId(int artistId)
        {
            return await _dbContext.FollowInfos
                .Where(f => f.FolloweeId == artistId)
                .Select(f => f.FollowerId)
                .ToListAsync();
        }

        public async Task<bool> UnFollowArtist(FollowInfos follow)
        {
            _dbContext.FollowInfos.Remove(follow);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> IsFollowed(int followerId, int followeeId)
        {
            return await _dbContext.FollowInfos
                .AnyAsync(f => f.FollowerId == followerId && f.FolloweeId == followeeId);
        }

        public async Task<int> GetFollowersCount(int artistId)
        {
            return await _dbContext.FollowInfos
                .CountAsync(f => f.FolloweeId == artistId);
        }

        public async Task<int> GetFollowingsCount(int followerId)
        {
            return await _dbContext.FollowInfos
                .CountAsync(f => f.FollowerId == followerId);
        }

        public async Task<IEnumerable<int>> GetListFollowingId(int followerId)
        {
            return await _dbContext.FollowInfos
                .Where(f => f.FollowerId == followerId)
                .Select(f => f.FolloweeId)
                .ToListAsync();
        }
    }
}
