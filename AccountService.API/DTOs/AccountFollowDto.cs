using Common.API.DTOs;

namespace AccountService.API.DTOs;

public record AccountFollowDto : BaseDto
{
    public required AccountDto FollowerAccount { get; set; }
    public required AccountDto FollowedAccount { get; set; }
}