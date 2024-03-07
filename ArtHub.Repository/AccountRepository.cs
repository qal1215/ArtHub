using ArtHub.BusinessObject;
using ArtHub.Repository.Contracts;
using SilverShopDAO;

namespace ArtHub.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public async Task<List<Member>> GetBranchAccountsAsync() => await AccountDAO.Instance.GetBranchAccountsAsync();

        public async Task AddBranchAccountAsync(Member branchAccount) => await AccountDAO.Instance.AddBranchAccountAsync(branchAccount);

        public async Task<Member?> GetBranchAccountAsync(string email) => await AccountDAO.Instance.GetBranchAccountAsync(email);

        public async Task<Member?> LoginAsync(string email, string password) => await AccountDAO.Instance.GetBranchAccountAsync(email, password);

        public async Task<bool> IsExistedAccount(string email) => await AccountDAO.Instance.IsExistedAccount(email);

        public async Task<bool> IsExistedAccount(int accountId) => await AccountDAO.Instance.IsExistedAccount(accountId);

        public async Task<Member?> GetBranchAccountByIdAsync(int memberId) => await AccountDAO.Instance.GetBranchAccountByIdAsync(memberId);

        public async Task<Member?> UpdateAccountAsync(int accountId, Member updateAccount)
        {
            var member = await AccountDAO.Instance.GetBranchAccountByIdAsync(accountId);

            if (member is not null)
            {
                if (updateAccount.EmailAddress != member.EmailAddress && updateAccount.EmailAddress != null)
                {
                    member.EmailAddress = updateAccount.EmailAddress;
                }

                if (updateAccount.FullName != member.FullName && updateAccount.FullName != null)
                {
                    member.FullName = updateAccount.FullName;
                }

                if (updateAccount.Avatar != member.Avatar && updateAccount.Avatar != null)
                {
                    member.Avatar = updateAccount.Avatar;
                }

                if (updateAccount.Role != member.Role && updateAccount.Role != null)
                {
                    member.Role = updateAccount.Role;
                }

                await AccountDAO.Instance.SaveChangeAsync();
            }
            return member;
        }

        public async Task<decimal> GetBalanceByAccountId(int accountId)
            => await AccountDAO.Instance.GetBranchAccountByIdAsync(accountId) is Member member ? member.Balance : -1;

        public async Task UpdateBalanceByAccountId(int memberId, decimal updateAmount)
        {
            var member = await AccountDAO.Instance.GetBranchAccountByIdAsync(memberId);
            member!.Balance = updateAmount;
            await AccountDAO.Instance.SaveChangeAsync();
        }
    }
}

