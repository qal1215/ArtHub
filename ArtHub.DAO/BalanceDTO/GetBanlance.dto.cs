using ArtHub.BusinessObject;
using System.ComponentModel.DataAnnotations;

namespace ArtHub.DTO.BalanceDTO
{
    public class GetBanlance
    {
        [Required]
        public int AccountId { get; set; }

        public TransactionType TransactionType { get; set; }

        public string FromDate { get; set; } = null!;

        public string ToDate { get; set; } = null!;
    }
}
