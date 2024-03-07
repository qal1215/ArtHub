using ArtHub.BusinessObject;
using ArtHub.DAO;
using ArtHub.DAO.BalanceDTO;
using ArtHub.Repository.Contracts;

namespace ArtHub.Repository
{
    public class TransactionHistoryRepository : ITransactionHistoryRepository
    {
        public async Task<HistoryTransaction> DepositAmountToAccount(TransactionAmount depositAmount, decimal currentBalance)
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

            return await HistoryTransactionDAO.Instance.AddHistoryTransactionAsync(historyTransaction);
        }

        public async Task<List<HistoryTransaction>> GetHistoryTransactionsByAccountId(int accountId)
        {
            return await HistoryTransactionDAO.Instance.GetHistoryTransactionByUserId(accountId);
        }

        public async Task<HistoryTransaction> WithdrawAmount(TransactionAmount withdrawAmount, decimal currentBalance)
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

            return await HistoryTransactionDAO.Instance.AddHistoryTransactionAsync(historyTransaction);
        }
    }
}
