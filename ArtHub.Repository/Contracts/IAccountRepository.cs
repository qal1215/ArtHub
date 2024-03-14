using ArtHub.BusinessObject;

namespace ArtHub.Repository.Contracts
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

        public Task<decimal> GetBalanceByAccountId(int memberId);

        public Task UpdateBalanceByAccountId(int memberId, decimal updateAmount);

        Task UpdateBalanceAccountForSell(int artworkId, decimal sellAmount);
        Task<Member?> GetBranchAccountByEmailAsync(string userEmail);
    }
}

