using SilverShopBusinessObject;

namespace SilverShopRepository
{
    public interface IAccountRepository
    {
        public Task<List<BranchAccount>> GetBranchAccountsAsync();

        public Task AddBranchAccountAsync(BranchAccount branchAccount);

        public Task<BranchAccount?> GetBranchAccountAsync(string email);

        public Task<bool> IsExistedEmail(string email);

        public Task<BranchAccount?> LoginAsync(string email, string password);
    }
}

