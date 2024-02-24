using Microsoft.EntityFrameworkCore;
using SilverShopBusinessObject;

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

        public async Task<List<BranchAccount>> GetBranchAccountsAsync()
        {
            return await dbContext.BranchAccounts.ToListAsync();
        }

        public async Task AddBranchAccountAsync(BranchAccount branchAccount)
        {
            await dbContext.AddAsync(branchAccount);
            dbContext.SaveChanges();
        }

        public async Task<BranchAccount?> GetBranchAccountAsync(string email)
        {
            return await dbContext.BranchAccounts.FirstOrDefaultAsync(m => m.EmailAddress!.Equals(email));
        }

        public async Task<bool> IsExistedEmail(string mail)
        {
            return await dbContext.BranchAccounts.AnyAsync(a => a.EmailAddress!.Equals(mail));
        }

        public async Task<BranchAccount?> GetBranchAccountAsync(string email, string password)
        {
            return await dbContext.BranchAccounts
                .FirstOrDefaultAsync(m => m.EmailAddress!.Equals(email) && m.AccountPassword!.Equals(password));
        }
    }
}

