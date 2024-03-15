using ArtHub.DTO.FollowDTO;
using ArtHub.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtHub.API.Controllers
{
    [Route("follow")]
    [ApiController]
    public class FollowController : ControllerBase
    {
        private readonly IFollowService _followService;


        public FollowController(IFollowService followService)
        {
            _followService = followService;
        }

        [Authorize]
        [HttpPost("")]
        public async Task<IActionResult> FollowArtist(CreateFollow createFollow)
        {
            var result = await _followService.FollowArtist(createFollow);
            if (result is false)
                return BadRequest();
            return Ok();
        }

        [Authorize]
        [HttpDelete("")]
        public async Task<IActionResult> UnFollowArtist(CreateFollow createFollow)
        {
            var result = await _followService.UnFollowArtist(createFollow);
            if (result is false)
                return BadRequest();
            return Ok();
        }

        [HttpGet("is-followed/{followerId}/{artistId}")]
        public async Task<IActionResult> IsFollowed(int followerId, int artistId)
        {
            var result = await _followService.IsFollowed(followerId, artistId);
            return Ok(new { isFollowed = result });
        }

        [HttpGet("followers-count/{artistId}")]
        public async Task<IActionResult> GetFollowersCount(int artistId)
        {
            var result = await _followService.GetFollowersCount(artistId);
            return Ok(new { followersCount = result });
        }

        [HttpGet("followings-count/{followerId}")]
        public async Task<IActionResult> GetFollowingsCount(int followerId)
        {
            var result = await _followService.GetFollowingsCount(followerId);
            return Ok(new { followingsCount = result });
        }

        [HttpGet("list-follower-id/{artistId}")]
        public async Task<IActionResult> GetListFollowerId(int artistId)
        {
            var result = await _followService.GetListFollowerId(artistId);
            return Ok(new { listFollowerId = result });
        }

        [HttpGet("list-following-id/{followerId}")]
        public async Task<IActionResult> GetListFollowingId(int followerId)
        {
            var result = await _followService.GetListFollowingId(followerId);
            return Ok(new { listFollowingId = result });
        }
    }
}
