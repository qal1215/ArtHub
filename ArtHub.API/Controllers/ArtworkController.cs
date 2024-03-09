using ArtHub.DAO.ArtworkDTO;
using ArtHub.DAO.ModelResult;
using ArtHub.Service.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace ArtHubAPI.Controllers
{
    [ApiController]
    [Route("artwork")]
    public class ArtworkController : ControllerBase
    {
        private readonly IArtworkService _artworkService;

        private readonly IMapper _mapper;

        public ArtworkController(IArtworkService artworkService, IMapper mapper)
        {
            _artworkService = artworkService;
            _mapper = mapper;
        }

        [EnableQuery]
        [HttpGet("{artworkId}")]
        //[Authorize]
        public async Task<IActionResult> GetArtworkById([FromRoute] int artworkId)
        {
            var artwork = await _artworkService.GetArtworkById(artworkId);
            if (artwork == null)
                return NotFound();
            return Ok(artwork);
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> AddArtwork([FromBody] CreateArtwork creating)
        {
            var newArtwork = await _artworkService.CreateArtwork(creating);
            return CreatedAtAction(nameof(GetArtworkById), new { artworkId = newArtwork.ArtworkId }, newArtwork);
        }

        [HttpGet("artist/{artistId}")]
        public async Task<IActionResult> GetArtworkByArtistId([FromRoute] int artistId)
        {
            var listArtwork = await _artworkService.GetArtworksByArtistId(artistId);
            if (listArtwork == null)
                return NotFound();

            return Ok(listArtwork);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllArtwork([FromQuery] QueryPaging queryPaging)
        {
            var artworkPaged = await _artworkService.GetArtworksPaging(queryPaging);
            return Ok(artworkPaged);
        }

        [HttpPut("{artworkId}")]
        public async Task<IActionResult> ReportArtwork(int artworkId)
        {
            var flag = await _artworkService.ReportArtwork(artworkId);

            if (flag)
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpPut("{artworkId}")]
        public async Task<IActionResult> UpdateArtwork([FromRoute] int artworkId, [FromBody] UpdateArtwork update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { msg = "Invalid model" });
            }

            if (artworkId != update.ArtworkId)
            {
                return BadRequest(new { msg = "Invalid artworkId" });
            }

            var result = await _artworkService.UpdateArtwork(update);

            return Ok(result);
        }

        [HttpDelete("{artworkId}")]
        public async Task<IActionResult> DeleteArtwork([FromRoute] int artworkId)
        {
            var result = await _artworkService.DeleteArtwork(artworkId);
            if (!result)
                return NotFound();
            return Ok();
        }
    }
}