using Common.Application.DTOs;

namespace AccountService.Application.DTOs;

public record AccountFollowEntityDto : BaseEntityDto
{
    public required AccountEntityDto FollowerAccount { get; set; }
    public required AccountEntityDto FollowedAccount { get; set; }
}