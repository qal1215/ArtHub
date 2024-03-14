namespace ArtHub.DTO.AccountDTO
{
    public class ResetPassword
    {
        public string EmailAddress { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }
    }
}
