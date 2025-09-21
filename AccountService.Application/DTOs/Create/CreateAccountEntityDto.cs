using System.ComponentModel.DataAnnotations;
using Common.Application.DTOs.Create;

namespace AccountService.Application.DTOs.Create;

public record CreateAccountEntityDto : CreateBaseEntityDto
{
    public Guid? GenderCode { get; set; }
    [Required(ErrorMessage = "Username is required")]
    public required string Username { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Guid? CountryCode { get; set; }
    public Guid? StateCode { get; set; }
    public Guid? CityCode { get; set; }
    public string? Biography { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public decimal? Weight { get; set; }
    public decimal? Height { get; set; }
    public bool Private { get; set; }
    public string? ProfilePicture { get; set; }
}