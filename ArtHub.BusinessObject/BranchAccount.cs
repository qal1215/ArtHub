using System.ComponentModel.DataAnnotations.Schema;

namespace SilverShopBusinessObject;

public partial class BranchAccount
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AccountId { get; set; }

    public string AccountPassword { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string? EmailAddress { get; set; }

    public int? Role { get; set; }
}
