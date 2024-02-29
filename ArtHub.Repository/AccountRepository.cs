using ArtHub.BusinessObject;
using SilverShopDAO;

namespace SilverShopRepository
{
    public class AccountRepository : IAccountRepository
    {
        public async Task<List<Member>> GetBranchAccountsAsync() => await AccountDAO.Instance.GetBranchAccountsAsync();

        public async Task AddBranchAccountAsync(Member branchAccount) => await AccountDAO.Instance.AddBranchAccountAsync(branchAccount);

        public async Task<Member?> GetBranchAccountAsync(string email) => await AccountDAO.Instance.GetBranchAccountAsync(email);

        public async Task<Member?> LoginAsync(string email, string password) => await AccountDAO.Instance.GetBranchAccountAsync(email, password);

        public async Task<bool> IsExistedEmail(string email) => await AccountDAO.Instance.IsExistedEmail(email);

        public async Task<Member?> GetBranchAccountByIdAsync(int memberId) => await AccountDAO.Instance.GetBranchAccountByIdAsync(memberId);
    }
}

