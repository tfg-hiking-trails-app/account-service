using Common.Application;

namespace AccountService.Application.DTOs.Update;

public record UpdateAccountEntityDto
{
    public Guid? GenderCode { get; set; }
    public string? Username { get; set; }
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
    public FileEntityDto? ProfilePicture { get; set; }
}