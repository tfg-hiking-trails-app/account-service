using Common.API.DTOs.Update;

namespace AccountService.API.DTOs.Update;

public record UpdateGenderDto : UpdateBaseDto
{
    public string? GenderValue { get; set; }
}