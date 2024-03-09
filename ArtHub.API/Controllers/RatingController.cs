using ArtHub.DAO.RatingDTO;
using ArtHub.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ArtHub.API.Controllers
{
    [Route("rating")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpPost("")]
        public async Task<IActionResult> AddRatingByArtworkId([FromBody] PostRating postRating)
        {
            var result = await _ratingService.AddOrUpdatingRatingForArtwork(postRating);
            if (!result) return BadRequest();

            return Ok();
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdatingRatingByArtworkId([FromBody] PostRating postRating)
        {
            var result = await _ratingService.AddOrUpdatingRatingForArtwork(postRating);
            if (!result) return BadRequest();

            return Ok();
        }

        [HttpDelete("")]
        public async Task<IActionResult> DeleteRating([FromBody] PostRating postRating)
        {
            var result = await _ratingService.UnRatingForArtwork(postRating);
            if (!result) return BadRequest();
            return Ok();
        }
    }
}
