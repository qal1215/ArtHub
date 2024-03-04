using ArtHub.BusinessObject;

namespace SilverShopRepository
{
    public interface IAccountRepository
    {
        public Task<List<Member>> GetBranchAccountsAsync();

        public Task AddBranchAccountAsync(Member branchAccount);

        public Task<Member?> GetBranchAccountAsync(string email);

        public Task<bool> IsExistedAccount(string email);

        public Task<bool> IsExistedAccount(int accountId);

        public Task<Member?> LoginAsync(string email, string password);

        public Task<Member?> GetBranchAccountByIdAsync(int memberId);

        public Task<Member?> UpdateAccountAsync(int accountId, Member account);
    }
}

