using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Domain.Entities;

namespace AccountService.Domain.Entities;

[Table("Subregion")]
public class Subregion : BaseEntity
{
    [Required]
    [Column("name")]
    [StringLength(100)]
    public required string Name { get; set; }

    [Column("translations", TypeName = "text")]
    public string? Translations { get; set; }

    [Column("region_id")]
    public uint RegionId { get; set; }

    [ForeignKey("RegionId")]
    public Region Region { get; set; } = null!;

    [Column("flag")]
    [DefaultValue(true)]
    public bool Flag { get; set; }

    [Column("wikiDataId")]
    [StringLength(255)]
    public string? WikiDataId { get; set; }

    public virtual ICollection<Country> Countries { get; set; } = new List<Country>();
}