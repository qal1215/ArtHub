using ArtHub.BusinessObject;

namespace ArtHub.Service.Contracts
{
    public interface IBalanceService
    {
        Task<List<HistoryTransaction>> GetHistoryTransactionsByAccountId(int accountId);

        Task<List<HistoryTransaction>> GetHistoryTransactionsByArtworkId(int artworkId);

        Task<HistoryTransaction> DepositBalanceAsync(int accountId, decimal amount);

        Task<HistoryTransaction> WithdrawBalanceAsync(int accountId, decimal amount);

        Task<HistoryTransaction> PurchaseArtworkAsync(int accountId, int artworkId, decimal amount);
    }
}
