namespace ArtHub.DAO.Account
{
    public class AccountDTO
    {
        public int? AccountId { get; set; }
        public string EmailAddress { get; set; } = null!;
        public string AccountPassword { get; set; } = null!;
        public string? FullName { get; set; }
    }
}
