using ArtHub.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ArtHub.API.Controllers
{
    [Route("admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("account")]
        public async Task<IActionResult> GetReports([FromQuery] string userEmail)
        {
            var account = await _adminService.GetUserByEmail(userEmail);
            if (account is null) return NotFound();
            return Ok(account);
        }
    }
}
