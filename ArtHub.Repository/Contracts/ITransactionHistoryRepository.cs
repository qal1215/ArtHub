using ArtHub.BusinessObject;
using ArtHub.DAO.BalanceDTO;

namespace ArtHub.Repository.Contracts
{
    public interface ITransactionHistoryRepository
    {
        Task<List<HistoryTransaction>> GetHistoryTransactionsByAccountId(int accountId);

        Task<HistoryTransaction> DepositAmountToAccount(TransactionAmount depositAmount, decimal currentBalance);

        Task<HistoryTransaction> WithdrawAmount(TransactionAmount withdrawAmount, decimal currentBalance);
    }
}
