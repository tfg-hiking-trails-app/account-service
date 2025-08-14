using Common.API.DTOs;

namespace AccountService.API.DTOs;

public record GenderDto : BaseDto
{
    public required string GenderValue { get; set; }
}