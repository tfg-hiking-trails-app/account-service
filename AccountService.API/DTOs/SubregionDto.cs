using Common.API.DTOs;

namespace AccountService.API.DTOs;

public record SubregionDto : BaseDto
{
    public required string Name { get; set; }
    public string? Translations { get; set; }
    public int RegionId { get; set; }
    public RegionDto? Region { get; set; }
    public bool Flag { get; set; }
    public string? WikiDataId { get; set; }
}