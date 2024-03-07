using ArtHub.BusinessObject;
using ArtHub.DAO.BalanceDTO;
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

        public async Task<List<HistoryTransaction>?> GetHistoryTransactionsByAccountId(int accountId)
        {
            var account = await _accountRepository.IsExistedAccount(accountId);
            if (!account) return null;
            return await _transactionHistoryRepository.GetHistoryTransactionsByAccountId(accountId);
        }

        public Task<List<HistoryTransaction>> GetHistoryTransactionsByArtworkId(int artworkId)
        {
            throw new NotImplementedException();
        }

        public async Task<HistoryTransaction?> DepositBalanceAsync(TransactionAmount depositAmount)
        {
            var currentBalance = await _accountRepository.GetBalanceByAccountId(depositAmount.AccountId);
            if (currentBalance < 0 || depositAmount.Amount < 0) return null;

            var transaction = await _transactionHistoryRepository.DepositAmountToAccount(depositAmount, currentBalance);
            if (transaction is null) return null;
            await _accountRepository.UpdateBalanceByAccountId(depositAmount.AccountId, transaction.AfterTransactionBalance);

            return transaction;
        }

        public async Task<HistoryTransaction?> WithdrawBalanceAsync(TransactionAmount withdrawAmount)
        {
            var currentBalance = await _accountRepository.GetBalanceByAccountId(withdrawAmount.AccountId);
            if (currentBalance < 0 || currentBalance < withdrawAmount.Amount) return null;

            var transaction = await _transactionHistoryRepository.WithdrawAmount(withdrawAmount, currentBalance);
            if (transaction is null) return null;
            await _accountRepository.UpdateBalanceByAccountId(withdrawAmount.AccountId, transaction.AfterTransactionBalance);

            return transaction;
        }

        public Task<HistoryTransaction> PurchaseArtworkAsync(int accountId, int artworkId, decimal amount)
        {
            throw new NotImplementedException();
        }

        public async Task<CurrentBalance?> GetBalanceByAccountId(int accountId)
        {
            var account = await _accountRepository.IsExistedAccount(accountId);
            if (!account) return null;
            var balance = await _accountRepository.GetBranchAccountByIdAsync(accountId);
            return _mapper.Map<CurrentBalance>(balance);
        }
    }
}
