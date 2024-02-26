using ArtHub.BusinessObject;

namespace ArtHub.Service
{
    public interface IAccountService
    {
        public Task<List<Member>?> GetBranchAccountsAsync();

        public Task<bool> AddBranchAccount(Member branchAccount);

        public Task<Member?> LoginAsync(string email, string password);

        public Task<bool> IsExistedAccount(string email);
    }
}
