using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Domain.Entities;

namespace AccountService.Domain.Entities;

[Table("City")]
public class City : BaseEntity
{
    [Required]
    [Column("name")]
    [StringLength(255)]
    public required string Name { get; set; }

    [Column("state_id")]
    public int StateId { get; set; }

    [ForeignKey("StateId")]
    public State State { get; set; } = null!;

    [Required]
    [Column("state_code")]
    [StringLength(255)]
    public required string StateCode { get; set; }

    [Column("country_id")]
    public int CountryId { get; set; }

    [ForeignKey("CountryId")]
    public Country Country { get; set; } = null!;

    [Required]
    [Column("country_code")]
    [StringLength(2)]
    public required string CountryCode { get; set; }

    [Required]
    [Column("latitude", TypeName = "decimal(10,8)")]
    public decimal Latitude { get; set; }

    [Required]
    [Column("longitude", TypeName = "decimal(11,8)")]
    public decimal Longitude { get; set; }

    [Column("timezone")]
    [StringLength(255)]
    public string? Timezone { get; set; }

    [Column("flag")]
    [DefaultValue(true)]
    public bool Flag { get; set; }

    [Column("wikiDataId")]
    [StringLength(255)]
    public string? WikiDataId { get; set; }
    
    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}