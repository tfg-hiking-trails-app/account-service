using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Domain.Entities;

namespace AccountService.Domain.Entities;

[Table("Gender")]
public class Gender : BaseEntity
{
    [Required]
    [Column("gender")]
    public required string GenderValue { get; set; }
    
    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}