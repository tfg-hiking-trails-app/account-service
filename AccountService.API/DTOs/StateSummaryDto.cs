using Common.API.DTOs;

namespace AccountService.API.DTOs;

public record StateSummaryDto : BaseDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
}