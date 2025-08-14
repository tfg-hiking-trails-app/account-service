using System.ComponentModel.DataAnnotations;
using Common.API.DataAnnotations;
using Common.API.DTOs.Create;

namespace AccountService.API.DTOs.Create;

public record CreateAccountFollowDto : CreateBaseDto
{
    [Required(ErrorMessage = "Follower Account Code is required")]
    [GuidValidator(ErrorMessage = "Follower Account Code is invalid")]
    public Guid? FollowerAccountCode { get; set; }
    [Required(ErrorMessage = "Followed Account Code is required")]
    [GuidValidator(ErrorMessage = "Followed Account Code is invalid")]
    public Guid? FollowedAccountCode { get; set; }
}