using System.ComponentModel.DataAnnotations;

namespace ArtHub.DTO.AccountDTO
{
    public class ResetPassword
    {
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
