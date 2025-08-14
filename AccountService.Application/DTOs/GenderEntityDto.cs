using Common.Application.DTOs;

namespace AccountService.Application.DTOs;

public record GenderEntityDto : BaseEntityDto
{
    public required string GenderValue { get; set; }
}