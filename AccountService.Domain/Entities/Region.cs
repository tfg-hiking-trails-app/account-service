using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Domain.Entities;

namespace AccountService.Domain.Entities;

[Table("Region")]
public class Region : BaseEntity
{
    [Required]
    [Column("name")]
    [StringLength(100)]
    public required string Name { get; set; }

    [Column("translations", TypeName = "text")]
    public string? Translations { get; set; }

    [Column("flag")]
    [DefaultValue(true)]
    public bool Flag { get; set; }

    [Column("wikiDataId")]
    [StringLength(255)]
    public string? WikiDataId { get; set; }

    public virtual ICollection<Country> Countries { get; set; } = new List<Country>();
    public virtual ICollection<Subregion> Subregions { get; set; } = new List<Subregion>();
}