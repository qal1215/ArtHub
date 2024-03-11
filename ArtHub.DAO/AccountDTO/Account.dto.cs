namespace ArtHub.DTO.AccountDTO
{
    public class ViewAccountDTO
    {
        public int AccountId { get; set; }

        public string FullName { get; set; } = null!;

        public string? EmailAddress { get; set; }

        public string? Avatar { get; set; }
    }
}
