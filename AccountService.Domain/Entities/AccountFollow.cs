using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Domain.Entities;

namespace AccountService.Domain.Entities;

[Table("AccountFollow")]
public class AccountFollow : BaseEntity
{
    [Required]
    [Column("follower_account_id")]
    public int FollowerAccountId { get; set; }

    [ForeignKey(nameof(FollowerAccountId))]
    public required Account FollowerAccount { get; set; }

    [Required]
    [Column("followed_account_id")]
    public int FollowedAccountId { get; set; }

    [ForeignKey(nameof(FollowedAccountId))]
    public required Account FollowedAccount { get; set; }
}