using ArtHub.DTO.BalanceDTO;
using ArtHub.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtHub.API.Controllers
{
    [Route("balance")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly IBalanceService _balanceService;

        public BalanceController(IBalanceService balanceService)
        {
            _balanceService = balanceService;
        }

        [Authorize]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetBalance(int userId)
        {
            if (userId <= 0)
                return BadRequest(new { msg = "Invalid input" });

            var balance = await _balanceService.GetBalanceByAccountId(userId);
            if (balance is null) return NotFound(new { msg = "Invalid user id" });

            return Ok(balance);
        }

        [Authorize]
        [HttpPost("history")]
        public async Task<IActionResult> GetHistoryAmount([FromBody] GetBanlance getBanlance)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (getBanlance.AccountId <= 0)
                return BadRequest(new { msg = "Invalid input" });

            var balanceHistory = await _balanceService.GetHistoryTransactionsByAccountId(getBanlance);

            if (balanceHistory is null)
            {
                return NotFound(new { msg = "Invalid user id" });
            }

            return Ok(balanceHistory);
        }

        [Authorize]
        [HttpPost("deposit")]
        public async Task<IActionResult> DepositAmountAsync([FromBody] TransactionAmount depositAmount)
        {
            if (depositAmount.AccountId <= 0)
                return BadRequest(new { msg = "Invalid input" });

            if (depositAmount.Amount <= 0)
                return BadRequest(new { msg = "Invalid input" });

            var balanceHistory = await _balanceService.DepositBalanceAsync(depositAmount);

            if (balanceHistory is null)
            {
                return BadRequest(new { msg = "Invalid transaction" });
            }

            return Ok(balanceHistory);
        }

        [Authorize]
        [HttpPost("withdraw")]
        public async Task<IActionResult> WithdrawAmountAsync([FromBody] TransactionAmount withdrawAmount)
        {
            if (withdrawAmount.AccountId <= 0)
                return BadRequest(new { msg = "Invalid input" });

            if (withdrawAmount.Amount <= 0)
                return BadRequest(new { msg = "Invalid input" });

            var balanceHistory = await _balanceService.WithdrawBalanceAsync(withdrawAmount);

            if (balanceHistory is null)
            {
                return BadRequest(new { msg = "Invalid transaction" });
            }

            return Ok(balanceHistory);
        }
    }
}
