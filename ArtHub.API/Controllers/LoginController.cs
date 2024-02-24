using ArtHub.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SilverShopBusinessObject;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ArtHubAPI.Controllers
{
    [ApiController]
    [Route("login")]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        private readonly IAccountService _accountService;

        public LoginController(IConfiguration config, IAccountService accountService)
        {
            _config = config;
            _accountService = accountService;

        }

        [AllowAnonymous]
        [HttpPost("/register")]
        public async Task<IActionResult> Register([FromBody] BranchAccount login)
        {

            if (login == null
                || string.IsNullOrEmpty(login.EmailAddress)
                || string.IsNullOrEmpty(login.EmailAddress)
                || string.IsNullOrEmpty(login.FullName)
                )
            {
                return BadRequest("Invalid client request");
            }

            IActionResult response = BadRequest();
            var userAdded = await _accountService.AddBranchAccount(login);

            if (userAdded)
            {
                var tokenString = GenerateJSONWebToken(login);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        [AllowAnonymous]
        [HttpPost("")]
        public async Task<IActionResult> LoginAsync([FromBody] BranchAccount login)
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
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string GenerateJSONWebToken(BranchAccount user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, user.EmailAddress!)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = credentials,
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Issuer"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}

