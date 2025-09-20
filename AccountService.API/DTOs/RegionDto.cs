using Common.API.DTOs;

namespace AccountService.API.DTOs;

public record RegionDto : BaseDto
{
    public required string Name { get; set; }
    public string? Translations { get; set; }
    public bool Flag { get; set; }
    public string? WikiDataId { get; set; }
}