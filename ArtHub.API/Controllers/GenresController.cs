using ArtHub.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ArtHub.API.Controllers
{
    [Route("genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllGenres()
        {
            var genres = await _genreService.GetGenresAsync();
            return Ok(genres);
        }
    }
}
