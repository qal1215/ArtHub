using ArtHub.BusinessObject;
using SilverShopRepository;

namespace ArtHub.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository = null;

        public AccountService()
        {
            _accountRepository = new AccountRepository();
        }


        public async Task<bool> AddBranchAccount(Member branchAccount)
        {
            try
            {
                var isExistedEmail = await _accountRepository.IsExistedEmail(branchAccount.EmailAddress!);

                if (isExistedEmail)
                {
                    return false;
                }

                await _accountRepository.AddBranchAccountAsync(branchAccount);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Member?> LoginAsync(string email, string password)
        {
            try
            {
                var account = await _accountRepository.LoginAsync(email.ToLower().Trim(), password);
                if (account is null)
                {
                    return null;
                }

                return account;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Member>?> GetBranchAccountsAsync()
        {
            try
            {
                var accounts = await _accountRepository.GetBranchAccountsAsync();
                return accounts;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> IsExistedAccount(string email)
        {
            var isExistedEmail = await _accountRepository.IsExistedEmail(email);
            return isExistedEmail;
        }

        public async Task<Member?> GetAccountById(int accountId) => await _accountRepository.GetBranchAccountByIdAsync(accountId);

    }
}
