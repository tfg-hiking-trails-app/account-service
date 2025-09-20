using Common.Application.DTOs;

namespace AccountService.Application.DTOs;

public record StateEntityDto : BaseEntityDto
{
    public required string Name { get; set; }
    public int CountryId { get; set; }
    public CountryEntityDto? Country { get; set; }
    public required string CountryCode { get; set; }
    public string? FipsCode { get; set; }
    public string? Iso2 { get; set; }
    public string? Iso3166_2 { get; set; }
    public string? Type { get; set; }
    public int? Level { get; set; }
    public int? ParentId { get; set; }
    public string? Native { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
    public string? Timezone { get; set; }
    public bool Flag { get; set; }
    public string? WikiDataId { get; set; }
}