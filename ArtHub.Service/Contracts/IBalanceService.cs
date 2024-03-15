using ArtHub.BusinessObject;
using ArtHub.DTO.BalanceDTO;

namespace ArtHub.Service.Contracts
{
    public interface IBalanceService
    {
        Task<List<HistoryTransaction>?> GetHistoryTransactionsByAccountId(GetBanlance getBalance);

        Task<List<HistoryTransaction>> GetHistoryTransactionsByArtworkId(int artworkId);

        Task<HistoryTransaction?> DepositBalanceAsync(TransactionAmount depositAmount);

        Task<HistoryTransaction?> WithdrawBalanceAsync(TransactionAmount withdrawAmount);

        Task<CurrentBalance?> GetBalanceByAccountId(int accountId);
        Task<HistoryTransaction?> SellBalanceAsync(TransactionAmount depositAmount, int artworkId);
        Task<HistoryTransaction?> PurchaseArtworkAsync(TransactionAmount purchaseAmount, int artworkId);
    }
}
