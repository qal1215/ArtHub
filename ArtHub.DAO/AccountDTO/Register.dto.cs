namespace ArtHub.DTO.AccountDTO
{
    public class Register
    {
        public string Password { get; set; } = null!;

        public string ConfirmPassword { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string? EmailAddress { get; set; }
    }
}
