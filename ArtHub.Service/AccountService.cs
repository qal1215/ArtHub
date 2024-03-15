using ArtHub.BusinessObject;
using ArtHub.DTO.AccountDTO;
using ArtHub.Repository.Contracts;
using ArtHub.Service.Contracts;
using AutoMapper;

namespace ArtHub.Service
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;

        public AccountService(IMapper mapper, IAccountRepository accountRepository)
        {
            _mapper = mapper;
            _accountRepository = accountRepository;
        }


        public async Task<bool> AddBranchAccount(Member branchAccount)
        {
            try
            {
                branchAccount.EmailAddress = branchAccount.EmailAddress!.ToLower().Trim();
                var isExistedEmail = await _accountRepository.IsExistedAccount(branchAccount.EmailAddress!);

                if (isExistedEmail)
                {
                    return false;
                }

                branchAccount.Role = Role.Member;
                await _accountRepository.AddBranchAccountAsync(branchAccount);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ViewAccount?> LoginAsync(string email, string password)
        {
            try
            {
                var account = await _accountRepository.LoginAsync(email.ToLower().Trim(), password);
                if (account is null)
                {
                    return null;
                }
                var viewAccount = _mapper.Map<ViewAccount>(account);
                return viewAccount;
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<ViewAccount>?> GetBranchAccountsAsync()
        {
            try
            {
                var accounts = await _accountRepository.GetBranchAccountsAsync();
                var viewAccounts = _mapper.Map<List<ViewAccount>>(accounts);
                return viewAccounts;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> IsExistedAccount(string email) => await _accountRepository.IsExistedAccount(email);



        public async Task<ViewAccount?> GetAccountById(int accountId)
        {
            var account = await _accountRepository.GetBranchAccountByIdAsync(accountId);
            var viewAccount = _mapper.Map<ViewAccount>(account);
            return viewAccount;
        }

        public async Task<ViewAccount?> UpdateAccount(int accountId, UpdateAccount account)
        {
            var member = _mapper.Map<Member>(account);
            var updatedMember = await _accountRepository.UpdateAccountAsync(accountId, member);
            var viewAccount = _mapper.Map<ViewAccount>(updatedMember);
            return viewAccount;
        }

        public async Task<bool> IsExistedAccount(int accountId) => await _accountRepository.IsExistedAccount(accountId);

        public async Task<bool> ResetPasswork(int accountId, ResetPassword resetPassword)
        {
            var account = await _accountRepository.GetBranchAccountByIdAsync(accountId);
            if (account is null || account.AccountId != accountId) return false;

            if (resetPassword.NewPassword != resetPassword.ConfirmPassword) return false;

            account.Password = resetPassword.NewPassword;

            var updated = await _accountRepository.UpdateAccountAsync(accountId, account);
            return updated is not null;
        }

        public async Task<ViewAccount?> GetUserByEmail(string userEmail)
        {
            var account = await _accountRepository.GetBranchAccountByEmailAsync(userEmail);
            if (account is null) return null;
            var viewAccount = _mapper.Map<ViewAccount>(account);
            return viewAccount;
        }
    }
}
