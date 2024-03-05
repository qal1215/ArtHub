using ArtHub.BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace ArtHub.DAO
{
    public class HistoryTransactionDAO
    {
        private static HistoryTransactionDAO instance = null;

        private readonly ArtHub2024DbContext dbContext = null;

        public HistoryTransactionDAO()
        {
            if (dbContext == null)
            {
                dbContext = new ArtHub2024DbContext();
            }
        }

        public static HistoryTransactionDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HistoryTransactionDAO();
                }
                return instance;
            }
        }

        public async Task<List<HistoryTransaction>> GetHistoryTransactionByUserId(int userId,
            TransactionType? type = null,
            DateTime? fromDate = null,
            DateTime? todate = null)
        {
            var history = dbContext.HistoryTransaction
                .Where(h => h.UserId == userId);

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

        public async Task<HistoryTransaction> AddHistoryTransactionAsync(HistoryTransaction historyTransaction)
        {
            await dbContext.AddAsync(historyTransaction);
            await dbContext.SaveChangesAsync();
            return historyTransaction;
        }

        public async Task<HistoryTransaction?> GetHistoryTransactionById(int historyTransactionId)
        {
            return await dbContext.HistoryTransaction.FirstOrDefaultAsync(h => h.HistoryTransactionId == historyTransactionId);
        }

        public async Task<HistoryTransaction?> GetHistoryTransactionByArtId(int artId)
        {
            return await dbContext.HistoryTransaction.FirstOrDefaultAsync(h => h.ArtId == artId);
        }
    }
}
