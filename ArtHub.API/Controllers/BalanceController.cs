using ArtHub.DAO.BalanceDTO;
using Microsoft.AspNetCore.Mvc;

namespace ArtHub.API.Controllers
{
    [Route("balance")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBalance()
        {
            return Ok("Balance");
        }

        [HttpPost("history")]
        public IActionResult GetHistoryAmount([FromBody] GetBanlance getBanlance)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (getBanlance.UserId <= 0)
                return BadRequest(new { msg = "Invalid input" });


            return Ok("History");
        }

        [HttpPost("deposit")]
        public IActionResult DepositAmount()
        {
            return Ok("DepositAmount Balance");
        }

        [HttpPost("withdraw")]
        public IActionResult WithdrawAmount()
        {
            return Ok("WithdrawAmount Balance");
        }
    }
}
