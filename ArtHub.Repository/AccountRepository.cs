using SilverShopBusinessObject;
using SilverShopDAO;

namespace SilverShopRepository
{
    public class AccountRepository : IAccountRepository
    {
        public async Task<List<BranchAccount>> GetBranchAccountsAsync() => await AccountDAO.Instance.GetBranchAccountsAsync();

        public async Task AddBranchAccountAsync(BranchAccount branchAccount) => await AccountDAO.Instance.AddBranchAccountAsync(branchAccount);

        public async Task<BranchAccount?> GetBranchAccountAsync(string email) => await AccountDAO.Instance.GetBranchAccountAsync(email);

        public async Task<BranchAccount?> LoginAsync(string email, string password) => await AccountDAO.Instance.GetBranchAccountAsync(email, password);

        public async Task<bool> IsExistedEmail(string email) => await AccountDAO.Instance.IsExistedEmail(email);
    }
}

