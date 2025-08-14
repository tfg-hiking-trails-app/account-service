using Common.API.DTOs.Update;

namespace AccountService.API.DTOs.Update;

public record UpdateAccountFollowDto : UpdateBaseDto
{
    public Guid? FollowedAccountCode { get; set; }
}