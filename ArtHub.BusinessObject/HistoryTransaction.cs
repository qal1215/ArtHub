namespace ArtHub.BusinessObject;

public class HistoryTransaction
{
    public int HistoryTransactionId { get; set; }

    public int ArtId { get; set; }

    public int AccountId { get; set; }

    public TransactionType TransactionType { get; set; }

    public DateTime TransactionDate { get; set; }

    public decimal TransactionAmount { get; set; }

    public decimal BeforeTransactionBalance { get; set; }

    public decimal AfterTransactionBalance { get; set; }
}

public enum TransactionType
{
    Deposit = 1,//Nap
    Withdraw = 2,//Rut
    Purchase = 3,//Mua
    Sell = 4,//Ban
}
