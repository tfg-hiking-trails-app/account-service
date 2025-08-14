using Common.API.DTOs.Create;

namespace AccountService.API.DTOs.Create;

public record CreateGenderDto : CreateBaseDto
{
    public required string GenderValue { get; set; }
}