using ArtHub.Service;
using Microsoft.AspNetCore.Mvc;

namespace ArtHub.API.Controllers
{
    [ApiController]
    [Route("profile")]
    public class MemberController : ControllerBase
    {
        private IAccountService _accountService;
        private IArtworkService _artworkService;

        public MemberController(IAccountService accountService, IArtworkService artworkService)
        {
            _accountService = accountService;
            _artworkService = artworkService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMemberProfileAsync(int id)
        {
            var member = await _accountService.GetAccountById(id);
            if (member is null)
            {
                return NotFound();
            }
            var memberArtworks = await _artworkService.GetArtworksByArtistId(id);

            member.Artworks = memberArtworks.ToArray();
            return Ok(member);
        }
    }
}
