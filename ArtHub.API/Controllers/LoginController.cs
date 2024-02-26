using ArtHub.BusinessObject;
using ArtHub.DAO.Account;
using ArtHub.Service;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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

        private readonly IMapper _mapper;

        public LoginController(IMapper mapper, IConfiguration config, IAccountService accountService)
        {
            _config = config;
            _accountService = accountService;
            _mapper = mapper;
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
                    var tokenString = GenerateJSONWebToken(account.EmailAddress!);
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
                var tokenString = GenerateJSONWebToken(user.EmailAddress!);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string GenerateJSONWebToken(string emailAddress)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, emailAddress)
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

