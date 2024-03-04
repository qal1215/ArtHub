using ArtHub.BusinessObject;
using ArtHub.DAO.AccountDTO;
using AutoMapper;
using SilverShopRepository;

namespace ArtHub.Service
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository = null;

        public AccountService(IMapper mapper)
        {
            _mapper = mapper;
            _accountRepository = new AccountRepository();
        }


        public async Task<bool> AddBranchAccount(Member branchAccount)
        {
            try
            {
                var isExistedEmail = await _accountRepository.IsExistedAccount(branchAccount.EmailAddress!);

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

        public async Task<bool> IsExistedAccount(string email) => await _accountRepository.IsExistedAccount(email);



        public async Task<Member?> GetAccountById(int accountId) => await _accountRepository.GetBranchAccountByIdAsync(accountId);

        public async Task<Member?> UpdateAccount(int accountId, UpdateAccount account)
        {
            var member = _mapper.Map<Member>(account);
            var updatedMember = await _accountRepository.UpdateAccountAsync(accountId, member);
            return updatedMember;
        }

        public async Task<bool> IsExistedAccount(int accountId) => await _accountRepository.IsExistedAccount(accountId);
    }
}
