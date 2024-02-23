using SilverShopBusinessObject;

namespace ArtHub.Service
{
    public interface IAccountService
    {
        public Task<List<BranchAccount>?> GetBranchAccountsAsync();

        public Task<bool> AddBranchAccount(BranchAccount branchAccount);

        public Task<BranchAccount?> LoginAsync(string email, string password);
    }
}
