namespace ArtHub.DAO.BalanceDTO
{
    public class CurrentBalance
    {
        public int AccountId { get; set; }

        public decimal Balance { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
