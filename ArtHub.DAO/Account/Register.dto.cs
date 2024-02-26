namespace ArtHub.DAO.Account
{
    public class Register
    {
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string? EmailAddress { get; set; }

        public AccountRole Role { get; set; }
    }

    public enum AccountRole
    {
        ADMIN = 0,
        AUDIENCE = 1,
        ARTIST = 2
    }
}
