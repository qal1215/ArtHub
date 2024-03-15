using ArtHub.BusinessObject;
using ArtHub.DTO.FollowDTO;
using ArtHub.Repository.Contracts;
using ArtHub.Service.Contracts;
using AutoMapper;

namespace ArtHub.Service
{
    public class FollowService : IFollowService
    {
        private readonly IMapper _mapper;
        private readonly IFollowRepository _followRepository;

        public FollowService(IMapper mapper, IFollowRepository followRepository)
        {
            _mapper = mapper;
            _followRepository = followRepository;
        }

        public async Task<bool> FollowArtist(CreateFollow createFollow)
        {
            var isFollowing = await _followRepository.IsFollowed(createFollow.FollowerId, createFollow.ArtistId);
            if (isFollowing) return true;
            var follow = _mapper.Map<FollowInfos>(createFollow);
            return await _followRepository.FollowArtist(follow);
        }

        public async Task<IEnumerable<int>> GetListFollowerId(int artistId)
        {
            return await _followRepository.GetListFollowerId(artistId);
        }

        public async Task<bool> UnFollowArtist(CreateFollow createFollow)
        {
            var follow = _mapper.Map<FollowInfos>(createFollow);
            return await _followRepository.UnFollowArtist(follow);
        }

        public async Task<bool> IsFollowed(int followerId, int followeeId)
        {
            return await _followRepository.IsFollowed(followerId, followeeId);
        }

        public async Task<int> GetFollowersCount(int artistId)
        {
            return await _followRepository.GetFollowersCount(artistId);
        }

        public async Task<int> GetFollowingsCount(int followerId)
        {
            return await _followRepository.GetFollowingsCount(followerId);
        }

        public async Task<IEnumerable<int>> GetListFollowingId(int followerId)
        {
            return await _followRepository.GetListFollowingId(followerId);
        }


    }
}
