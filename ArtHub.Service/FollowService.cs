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
            var follow = _mapper.Map<FollowInfos>(createFollow);
            return await _followRepository.FollowArtist(follow);
        }


    }
}
