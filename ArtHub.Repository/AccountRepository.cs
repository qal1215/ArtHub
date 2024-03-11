using ArtHub.BusinessObject;
using ArtHub.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ArtHub.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ArtHub2024DbContext _dbContext;

        public AccountRepository(ArtHub2024DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Member>> GetBranchAccountsAsync()
            => await _dbContext.Members.ToListAsync();

        public async Task AddBranchAccountAsync(Member branchAccount)
        {
            await _dbContext.AddAsync(branchAccount);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Member?> GetBranchAccountAsync(string email)
            => await _dbContext.Members.FirstOrDefaultAsync(m => m.EmailAddress!.Equals(email));

        public async Task<Member?> LoginAsync(string email, string password)
            => await _dbContext.Members
                .FirstOrDefaultAsync(m => m.EmailAddress!.Equals(email) && m.Password!.Equals(password));

        public async Task<bool> IsExistedAccount(string email)
        {
            var result = await _dbContext.Members.AnyAsync(m => m.EmailAddress == email);
            return result;
        }

        public async Task<bool> IsExistedAccount(int accountId)
        {
            var result = await _dbContext.Members.AnyAsync(a => a.AccountId == accountId);
            return result;
        }

        public async Task<Member?> GetBranchAccountByIdAsync(int memberId)
        {
            var result = await _dbContext.Members.FirstOrDefaultAsync(m => m.AccountId == memberId);

            return result;
        }

        public async Task<Member?> UpdateAccountAsync(int accountId, Member updateAccount)
        {
            var member = await _dbContext.Members
                .FirstOrDefaultAsync(m => m.AccountId == accountId);

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

                await _dbContext.SaveChangesAsync();
            }
            return member;
        }

        public async Task<decimal> GetBalanceByAccountId(int accountId)
            => await _dbContext.Members.FirstOrDefaultAsync(a => a.AccountId == accountId)
            is Member member
            ? member.Balance
            : -1;

        public async Task UpdateBalanceByAccountId(int accountId, decimal updateAmount)
        {
            var member = await _dbContext.Members
                .FirstOrDefaultAsync(m => m.AccountId == accountId);
            member!.Balance = updateAmount;
            await _dbContext.SaveChangesAsync();
        }
    }
}

