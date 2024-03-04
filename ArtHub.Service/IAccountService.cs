using ArtHub.BusinessObject;
using ArtHub.DAO.AccountDTO;

namespace ArtHub.Service
{
    public interface IAccountService
    {
        public Task<List<Member>?> GetBranchAccountsAsync();

        public Task<bool> AddBranchAccount(Member branchAccount);

        public Task<Member?> LoginAsync(string email, string password);

        public Task<bool> IsExistedAccount(string email);

        public Task<bool> IsExistedAccount(int accountId);

        public Task<Member?> GetAccountById(int accountId);

        public Task<Member?> UpdateAccount(int accountId, UpdateAccount account);
    }
}
