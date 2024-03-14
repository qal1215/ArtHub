using ArtHub.BusinessObject;
using ArtHub.DTO.AccountDTO;

namespace ArtHub.Service.Contracts
{
    public interface IAccountService
    {
        public Task<List<ViewAccount>?> GetBranchAccountsAsync();

        public Task<bool> AddBranchAccount(Member branchAccount);

        public Task<ViewAccount?> LoginAsync(string email, string password);

        public Task<bool> IsExistedAccount(string email);

        public Task<bool> IsExistedAccount(int accountId);

        public Task<ViewAccount?> GetAccountById(int accountId);

        public Task<ViewAccount?> UpdateAccount(int accountId, UpdateAccount account);
        Task<bool> ResetPasswork(int accountId, ResetPassword resetPassword);
        Task<ViewAccount?> GetUserByEmail(string userEmail);
    }
}
