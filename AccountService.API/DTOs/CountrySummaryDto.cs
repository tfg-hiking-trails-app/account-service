using Common.API.DTOs;

namespace AccountService.API.DTOs;

public record CountrySummaryDto : BaseDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
}