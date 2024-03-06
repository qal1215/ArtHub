using ArtHub.DAO.AccountDTO;
using ArtHub.Service.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtHub.API.Controllers
{
    [ApiController]
    [Route("profile")]
    public class MemberController : ControllerBase
    {
        private IMapper _mapper;
        private IAccountService _accountService;
        private IArtworkService _artworkService;

        public MemberController(IMapper mapper, IAccountService accountService, IArtworkService artworkService)
        {
            _mapper = mapper;
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMemberProfileAsync(int id, [FromBody] UpdateAccount account)
        {
            if (id != account.Id)
            {
                return BadRequest();
            }

            var isExisted = await _accountService.IsExistedAccount(account.EmailAddress!);

            if (!isExisted)
            {
                return Unauthorized();
            }

            var updatedAccount = await _accountService.UpdateAccount(id, account);
            if (updatedAccount is null)
            {
                return NotFound();
            }

            return Ok(updatedAccount);
        }
    }
}
