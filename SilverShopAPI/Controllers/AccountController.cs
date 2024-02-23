using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SilverShopBusinessObject;
using SilverShopRepository;

namespace ArtHubAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [EnableQuery]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> getAllAccountsAsync()
        {
            List<BranchAccount> brandAccounts = await _accountRepository.GetBranchAccountsAsync();
            return Ok(brandAccounts);
        }



        [HttpPost]
        public async Task<IActionResult> AddBranchAccountAsync(BranchAccount branchAccount)
        {
            BranchAccount? branchAcc = await _accountRepository.GetBranchAccountAsync(branchAccount.EmailAddress);
            if (branchAcc == null)
            {
                await _accountRepository.AddBranchAccountAsync(branchAccount);
                return Ok(branchAccount);
            }
            return NotFound();
        }
    }
}

