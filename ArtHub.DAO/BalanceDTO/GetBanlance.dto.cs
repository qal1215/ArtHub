using ArtHub.BusinessObject;

namespace ArtHub.DAO.BalanceDTO
{
    public class GetBanlance
    {
        public int UserId { get; set; }

        public TransactionType TransactionType { get; set; }

        public string FromDate { get; set; } = null!;

        public string ToDate { get; set; } = null!;
    }
}
