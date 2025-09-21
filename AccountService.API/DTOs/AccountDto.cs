using Common.API.DTOs;

namespace AccountService.API.DTOs;

public record AccountDto : BaseDto
{
    public GenderDto? Gender { get; set; }
    public required string Username { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public CountryDto? Country { get; set; }
    public StateDto? State { get; set; }
    public CityDto? City { get; set; }
    public string? Biography { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public decimal? Weight { get; set; }
    public decimal? Height { get; set; }
    public bool Private { get; set; }
    public string? ProfilePicture { get; set; }

    //public ICollection<AccountFollowDto> Following { get; set; } = new List<AccountFollowDto>();
    //public ICollection<AccountFollowDto> Followers { get; set; } = new List<AccountFollowDto>();
}