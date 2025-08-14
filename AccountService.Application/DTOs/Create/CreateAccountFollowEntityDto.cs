using Common.Application.DTOs.Create;

namespace AccountService.Application.DTOs.Create;

public record CreateAccountFollowEntityDto : CreateBaseEntityDto
{
    public Guid? FollowerAccountCode { get; set; }
    public Guid? FollowedAccountCode { get; set; }
}