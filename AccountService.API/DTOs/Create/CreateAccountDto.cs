using System.ComponentModel.DataAnnotations;
using Common.API.DTOs.Create;

namespace AccountService.API.DTOs.Create;

public record CreateAccountDto : CreateBaseDto
{
    public Guid? GenderCode { get; set; }
    [Required(ErrorMessage = "Username is required")]
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
}