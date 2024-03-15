using ArtHub.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtHub.Repository.Contracts
{
    public interface IFollowRepository
    {
        Task<bool> FollowArtist(FollowInfos follow);
        Task<int> GetFollowersCount(int artistId);
        Task<int> GetFollowingsCount(int followerId);
        Task<IEnumerable<int>> GetListFollowerId(int artistId);
        Task<IEnumerable<int>> GetListFollowingId(int followerId);
        Task<bool> IsFollowed(int followerId, int followeeId);
        Task<bool> UnFollowArtist(FollowInfos follow);
    }
}
