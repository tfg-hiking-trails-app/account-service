using Common.Application.DTOs;

namespace AccountService.Application.DTOs;

public record SubregionEntityDto : BaseEntityDto
{
    public required string Name { get; set; }
    public string? Translations { get; set; }
    public int RegionId { get; set; }
    public RegionEntityDto? Region { get; set; }
    public bool Flag { get; set; }
    public string? WikiDataId { get; set; }
}