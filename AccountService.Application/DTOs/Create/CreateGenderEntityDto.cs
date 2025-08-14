using Common.Application.DTOs.Create;

namespace AccountService.Application.DTOs.Create;

public record CreateGenderEntityDto : CreateBaseEntityDto
{
    public required string GenderValue { get; set; }
}