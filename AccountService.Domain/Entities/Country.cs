using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Domain.Entities;

namespace AccountService.Domain.Entities;

[Table("Country")]
public class Country : BaseEntity
{
    [Required]
    [Column("name")]
    [StringLength(100)]
    public required string Name { get; set; }

    [Column("iso3")]
    [StringLength(3)]
    public string? Iso3 { get; set; }

    [Column("numeric_code")]
    [StringLength(3)]
    public string? NumericCode { get; set; }

    [Column("iso2")]
    [StringLength(2)]
    public string? Iso2 { get; set; }

    [Column("phonecode")]
    [StringLength(255)]
    public string? PhoneCode { get; set; }

    [Column("capital")]
    [StringLength(255)]
    public string? Capital { get; set; }

    [Column("currency")]
    [StringLength(255)]
    public string? Currency { get; set; }

    [Column("currency_name")]
    [StringLength(255)]
    public string? CurrencyName { get; set; }

    [Column("currency_symbol")]
    [StringLength(255)]
    public string? CurrencySymbol { get; set; }

    [Column("tld")]
    [StringLength(255)]
    public string? Tld { get; set; }

    [Column("native")]
    [StringLength(255)]
    public string? Native { get; set; }

    [Column("region")]
    [StringLength(255)]
    public string? Region { get; set; }

    [Column("region_id")]
    public int? RegionId { get; set; }

    [ForeignKey("RegionId")]
    public Region? RegionEntity { get; set; }

    [Column("subregion")]
    [StringLength(255)]
    public string? Subregion { get; set; }

    [Column("subregion_id")]
    public int? SubregionId { get; set; }

    [ForeignKey("SubregionId")]
    public Subregion? SubregionEntity { get; set; }

    [Column("nationality")]
    [StringLength(255)]
    public string? Nationality { get; set; }

    [Column("timezones", TypeName = "text")]
    public string? Timezones { get; set; }

    [Column("translations", TypeName = "text")]
    public string? Translations { get; set; }

    [Column("latitude", TypeName = "decimal(10,8)")]
    public decimal? Latitude { get; set; }

    [Column("longitude", TypeName = "decimal(11,8)")]
    public decimal? Longitude { get; set; }

    [Column("emoji")]
    [StringLength(191)]
    public string? Emoji { get; set; }

    [Column("emojiU")]
    [StringLength(191)]
    public string? EmojiU { get; set; }

    [Column("flag")]
    [DefaultValue(true)]
    public bool Flag { get; set; }

    [Column("wikiDataId")]
    [StringLength(255)]
    public string? WikiDataId { get; set; }
    
    public virtual ICollection<State> States { get; set; } = new List<State>();
    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}