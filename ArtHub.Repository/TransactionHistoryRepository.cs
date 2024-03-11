using ArtHub.BusinessObject;
using ArtHub.DAO.BalanceDTO;
using ArtHub.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ArtHub.Repository
{
    public class TransactionHistoryRepository : ITransactionHistoryRepository
    {
        private readonly ArtHub2024DbContext _dbContext;

        public TransactionHistoryRepository(ArtHub2024DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<HistoryTransaction?> DepositAmountToAccount(TransactionAmount depositAmount, decimal currentBalance)
        {
            HistoryTransaction historyTransaction = new()
            {
                AccountId = depositAmount.AccountId,
                ArtId = -1,
                BeforeTransactionBalance = currentBalance,
                AfterTransactionBalance = currentBalance + depositAmount.Amount,
                TransactionAmount = depositAmount.Amount,
                TransactionDate = DateTime.Now,
                TransactionType = TransactionType.Deposit
            };

            await _dbContext.AddAsync(historyTransaction);
            var result = await _dbContext.SaveChangesAsync();
            if (result <= 0)
                return null;

            return historyTransaction;
        }

        public async Task<List<HistoryTransaction>> GetHistoryTransactionsByAccountId(int accountId,
            TransactionType? type = null,
            DateTime? fromDate = null,
            DateTime? todate = null)
        {
            var history = _dbContext.HistoryTransaction
                .Where(h => h.AccountId == accountId);

            if (type is not null)
            {
                history = history.Where(h => h.TransactionType == type);
            }

            if (fromDate is not null && todate is not null)
            {
                history = history.Where(h => h.TransactionDate >= fromDate && h.TransactionDate <= todate);
            }

            return await history.ToListAsync();
        }

        public async Task<HistoryTransaction?> WithdrawAmount(TransactionAmount withdrawAmount, decimal currentBalance)
        {
            HistoryTransaction historyTransaction = new()
            {
                AccountId = withdrawAmount.AccountId,
                ArtId = -1,
                BeforeTransactionBalance = currentBalance,
                AfterTransactionBalance = currentBalance - withdrawAmount.Amount,
                TransactionAmount = withdrawAmount.Amount,
                TransactionDate = DateTime.Now,
                TransactionType = TransactionType.Withdraw
            };

            await _dbContext.AddAsync(historyTransaction);
            var result = await _dbContext.SaveChangesAsync();

            if (result <= 0)
            {
                return null;
            }

            return historyTransaction;
        }
    }
}
