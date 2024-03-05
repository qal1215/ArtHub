using ArtHub.BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace SilverShopDAO
{
    public class AccountDAO
    {
        private static AccountDAO instance = null;
        private readonly ArtHub2024DbContext dbContext = null;
        public AccountDAO()
        {
            if (dbContext == null)
            {
                dbContext = new ArtHub2024DbContext();
            }
        }

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }
        }

        public async Task<List<Member>> GetBranchAccountsAsync()
        {
            return await dbContext.Members.ToListAsync();
        }

        public async Task AddBranchAccountAsync(Member branchAccount)
        {
            await dbContext.AddAsync(branchAccount);
            dbContext.SaveChanges();
        }

        public async Task<Member?> GetBranchAccountAsync(string email)
        {
            return await dbContext.Members.FirstOrDefaultAsync(m => m.EmailAddress!.Equals(email));
        }

        public async Task<Member?> GetBranchAccountByIdAsync(int accountId)
        {
            return await dbContext.Members.FirstOrDefaultAsync(m => m.AccountId == accountId);
        }

        public async Task<bool> IsExistedAccount(string mail)
        {
            return await dbContext.Members.AnyAsync(a => a.EmailAddress!.Equals(mail));
        }

        public async Task<bool> IsExistedAccount(int accountId)
        {
            return await dbContext.Members.AnyAsync(a => a.AccountId == accountId);
        }

        public async Task<Member?> GetBranchAccountAsync(string email, string password)
        {
            return await dbContext.Members
                .FirstOrDefaultAsync(m => m.EmailAddress!.Equals(email) && m.Password!.Equals(password));
        }

        public async Task SaveChangeAsync()
        {
            await dbContext.SaveChangesAsync();
            return;
        }

        public async Task<bool> UpdateAccountBalance(int accountId, decimal currentBalance)
        {
            var account = await dbContext.Members.FirstOrDefaultAsync(a => a.AccountId == accountId);
            if (account is null || currentBalance < 0)
            {
                return false;
            }
            account.Balance = currentBalance;
            await dbContext.SaveChangesAsync();
            return true;
        }
    }
}

