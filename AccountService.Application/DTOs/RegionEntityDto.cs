using Common.Application.DTOs;

namespace AccountService.Application.DTOs;

public record RegionEntityDto : BaseEntityDto
{
    public required string Name { get; set; }
    public string? Translations { get; set; }
    public bool Flag { get; set; }
    public string? WikiDataId { get; set; }
}