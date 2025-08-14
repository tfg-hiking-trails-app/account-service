namespace AccountService.Application.DTOs.Update;

public record UpdateAccountFollowEntityDto
{
    public Guid? FollowedAccountCode { get; set; }
}