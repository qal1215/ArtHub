using Microsoft.AspNetCore.Mvc;

namespace ArtHub.API.Controllers
{
    [Route("follow")]
    [ApiController]
    public class FollowController : ControllerBase
    {
        public FollowController()
        {
        }

        [HttpGet("followers/{userId}")]
        public async Task<IActionResult> GetFollowers(int userId)
        {
            return Ok();
        }

        [HttpGet("following/{userId}")]
        public async Task<IActionResult> GetFollowing(int userId)
        {
            return Ok();
        }

        [HttpPost("")]
        public async Task<IActionResult> Follow()
        {
            return Ok();
        }

    }
}
