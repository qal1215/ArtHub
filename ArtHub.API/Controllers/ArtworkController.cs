using ArtHub.Service.ArtworkService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace ArtHubAPI.Controllers
{
    [ApiController]
    [Route("artwork")]
    public class ArtworkController : ControllerBase
    {
        private readonly IArtworkService _artworkService;
        public ArtworkController(IArtworkService artworkService)
        {
            _artworkService = artworkService;
        }

        [EnableQuery]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetArtworkById([FromRoute] int artworkId)
        {
            var artwork = await _artworkService.GetArtworkById(artworkId);
            if (artwork == null)
                return NotFound();
            return Ok(artwork);
        }
    }
}

