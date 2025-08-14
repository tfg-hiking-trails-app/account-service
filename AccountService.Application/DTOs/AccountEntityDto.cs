using Common.Application.DTOs;

namespace AccountService.Application.DTOs;

public record AccountEntityDto : BaseEntityDto
{
    public GenderEntityDto? Gender { get; set; }
    public required string Username { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? Biography { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public decimal? Weight { get; set; }
    public decimal? Height { get; set; }
    public bool Private { get; set; }
    public string? ProfilePicture { get; set; }

    //public ICollection<AccountFollowEntityDto> Following { get; set; } = new List<AccountFollowEntityDto>();
    //public ICollection<AccountFollowEntityDto> Followers { get; set; } = new List<AccountFollowEntityDto>();
}