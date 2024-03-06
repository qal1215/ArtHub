using ArtHub.BusinessObject;
using ArtHub.Repository;
using ArtHub.Repository.Contracts;
using ArtHub.Service.Contracts;
using AutoMapper;

namespace ArtHub.Service
{
    public class BalanceService : IBalanceService
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository = null;
        private readonly ITransactionHistoryRepository _transactionHistoryRepository = null;

        public BalanceService(IMapper mapper)
        {
            _mapper = mapper;
            _accountRepository = new AccountRepository();
            _transactionHistoryRepository = new TransactionHistoryRepository();
        }

        public Task<List<HistoryTransaction>> GetHistoryTransactionsByAccountId(int accountId)
        {
            throw new NotImplementedException();
        }

        public Task<List<HistoryTransaction>> GetHistoryTransactionsByArtworkId(int artworkId)
        {
            throw new NotImplementedException();
        }

        public Task<HistoryTransaction> DepositBalanceAsync(int accountId, decimal amount)
        {
            throw new NotImplementedException();
        }

        public Task<HistoryTransaction> WithdrawBalanceAsync(int accountId, decimal amount)
        {
            throw new NotImplementedException();
        }

        public Task<HistoryTransaction> PurchaseArtworkAsync(int accountId, int artworkId, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
