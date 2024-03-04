namespace ArtHub.DAO.AccountDTO
{
    public class UpdateAccount
    {
        public int Id { get; set; }

        public string? FullName { get; set; } = null!;

        public string? EmailAddress { get; set; }

        public string? Avatar { get; set; }
    }

    public class UpdatePassword
    {
        public int Id { get; set; }

        public string Password { get; set; } = null!;

        public string NewPassword { get; set; } = null!;

        public string ConfirmPassword { get; set; } = null!;
    }
}
