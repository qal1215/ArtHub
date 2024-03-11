using ArtHub.BusinessObject;
using ArtHub.DTO.BalanceDTO;

namespace ArtHub.Service.Contracts
{
    public interface IBalanceService
    {
        Task<List<HistoryTransaction>?> GetHistoryTransactionsByAccountId(int accountId);

        Task<List<HistoryTransaction>> GetHistoryTransactionsByArtworkId(int artworkId);

        Task<HistoryTransaction?> DepositBalanceAsync(TransactionAmount depositAmount);

        Task<HistoryTransaction?> WithdrawBalanceAsync(TransactionAmount withdrawAmount);

        Task<HistoryTransaction> PurchaseArtworkAsync(int accountId, int artworkId, decimal amount);

        Task<CurrentBalance?> GetBalanceByAccountId(int accountId);
    }
}
