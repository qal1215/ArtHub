using ArtHub.BusinessObject;
using ArtHub.DAO.ArtworkDTO;
using ArtHub.Service.ArtworkService;
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
            var artwork = _mapper.Map<Artwork>((object)creating);
            var newArtwork = await _artworkService.CreateArtwork(artwork);
            return CreatedAtAction(nameof(GetArtworkById), new { artworkId = newArtwork.ArtworkID }, newArtwork);
        }

        [HttpGet("artist/{artistId}")]
        public async Task<IActionResult> GetArtworkByArtistId([FromRoute] int artistId)
        {
            var listArtwork = await _artworkService.GetArtworksByArtistId(artistId);
            if (listArtwork == null)
                return NotFound();

            return Ok(listArtwork);
        }
    }
}

