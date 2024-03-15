using ArtHub.API.Helpers;
using ArtHub.BusinessObject;
using ArtHub.DTO.AccountDTO;
using ArtHub.Service.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtHubAPI.Controllers
{
    [ApiController]
    [Route("login")]
    public class LoginController : ControllerBase
    {

        private readonly IAccountService _accountService;

        private readonly IMapper _mapper;

        private readonly JwtTokenHelper _jwtTokenHelper;

        public LoginController(IMapper mapper, IConfiguration config, IAccountService accountService)
        {
            _accountService = accountService;
            _mapper = mapper;
            _jwtTokenHelper = new JwtTokenHelper(config);
        }

        [AllowAnonymous]
        [HttpPost("/register")]
        public async Task<IActionResult> Register([FromBody] Register registed)
        {

            if (registed == null
                || string.IsNullOrEmpty(registed.EmailAddress)
                || string.IsNullOrEmpty(registed.Password)
                || string.IsNullOrEmpty(registed.ConfirmPassword)
                || string.IsNullOrEmpty(registed.FullName)
                )
            {
                return BadRequest("Invalid client request");
            }

            if (registed.Password != registed.ConfirmPassword)
            {
                return BadRequest("Password and Confirm Password do not match");
            }

            var isExisted = await _accountService.IsExistedAccount(registed.EmailAddress);
            if (isExisted)
            {
                return BadRequest("Email is registed!");
            }

            IActionResult response = BadRequest();
            try
            {
                var account = _mapper.Map<Member>(registed);
                var userAdded = await _accountService.AddBranchAccount(account);

                if (userAdded)
                {
                    var tokenString = _jwtTokenHelper.GenerateJSONWebToken(account.EmailAddress!, account.AccountId, (int)account.Role!, account.FullName);
                    response = Ok(new { token = tokenString });
                }
            }
            catch (Exception e)
            {
                response = BadRequest(e.Message);
            }

            return response;
        }

        [AllowAnonymous]
        [HttpPost("/login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDTO login)
        {
            if (login == null
                || string.IsNullOrEmpty(login.EmailAddress)
                || string.IsNullOrEmpty(login.EmailAddress)
                )
            {
                return BadRequest("Invalid client request");
            }

            IActionResult response = Unauthorized();
            var user = await _accountService.LoginAsync(login.EmailAddress, login.AccountPassword);

            if (user != null)
            {
                var tokenString = _jwtTokenHelper.GenerateJSONWebToken(user.EmailAddress!, user.AccountId, (int)user.Role!, user.FullName);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        [AllowAnonymous]
        [HttpPost("/reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPassword resetPassword)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var isValid = _jwtTokenHelper.ValidateJSONWebToken(resetPassword.Token);
            if (!isValid) return Unauthorized();

            var accountIdString = _jwtTokenHelper.GetClaim(resetPassword.Token, "MemberId");
            if (!int.TryParse(accountIdString, out var accountId)) return Unauthorized();

            var result = await _accountService.ResetPasswork(accountId, resetPassword);
            if (!result) return BadRequest();

            return Ok(new { msg = "Change password successfully" });
        }
    }
}

