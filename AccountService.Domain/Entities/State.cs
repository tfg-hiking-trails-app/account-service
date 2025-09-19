using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Domain.Entities;

namespace AccountService.Domain.Entities;

[Table("State")]
public class State : BaseEntity
{
    [Required]
    [Column("name")]
    [StringLength(255)]
    public required string Name { get; set; }

    [Column("country_id")]
    public uint CountryId { get; set; }

    [ForeignKey("CountryId")]
    public Country Country { get; set; } = null!;

    [Required]
    [Column("country_code")]
    [StringLength(2)]
    public required string CountryCode { get; set; }

    [Column("fips_code")]
    [StringLength(255)]
    public string? FipsCode { get; set; }

    [Column("iso2")]
    [StringLength(255)]
    public string? Iso2 { get; set; }

    [Column("iso3166_2")]
    [StringLength(10)]
    public string? Iso3166_2 { get; set; }

    [Column("type")]
    [StringLength(191)]
    public string? Type { get; set; }

    [Column("level")]
    public int? Level { get; set; }

    [Column("parent_id")]
    public uint? ParentId { get; set; }

    [Column("native")]
    [StringLength(255)]
    public string? Native { get; set; }

    [Column("latitude", TypeName = "decimal(10,8)")]
    public decimal? Latitude { get; set; }

    [Column("longitude", TypeName = "decimal(11,8)")]
    public decimal? Longitude { get; set; }

    [Column("timezone")]
    [StringLength(255)]
    public string? Timezone { get; set; }

    [Column("flag")]
    [DefaultValue(true)]
    public bool Flag { get; set; }

    [Column("wikiDataId")]
    [StringLength(255)]
    public string? WikiDataId { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}