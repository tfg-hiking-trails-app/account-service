using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Domain.Entities;

namespace AccountService.Domain.Entities;

[Table("Account")]
public class Account : BaseEntity
{
    [Column("gender_id")]
    public int? GenderId { get; set; }
    
    [ForeignKey("GenderId")]
    public Gender? Gender { get; set; }
    
    [Required]
    [Column("username")]
    public required string Username { get; set; }
    
    [Column("first_name")]
    [StringLength(50)]
    public string? FirstName { get; set; }

    [Column("last_name")]
    [StringLength(50)]
    public string? LastName { get; set; }

    [Column("country_code")]
    public Guid? CountryCode { get; set; }
    
    [Column("state_code")]
    public Guid? StateCode { get; set; }
    
    [Column("city_code")]
    public Guid? CityCode { get; set; }

    [Column("biography", TypeName = "text")]
    public string? Biography { get; set; }
    
    [Column("date_of_birth", TypeName = "date")]
    public DateOnly? DateOfBirth { get; set; }

    [Column("weight", TypeName = "decimal(5,2)")]
    public decimal? Weight { get; set; }

    [Column("height", TypeName = "decimal(5,2)")]
    public decimal? Height { get; set; }

    [Column("profile_picture")]
    [StringLength(255)]
    public string? ProfilePicture { get; set; }
    
    [Column("deleted")]
    [DefaultValue(false)]
    public bool Deleted { get; set; }
    
    public virtual ICollection<AccountFollow> Following { get; set; } = new List<AccountFollow>();
    public virtual ICollection<AccountFollow> Followers { get; set; } = new List<AccountFollow>();
}