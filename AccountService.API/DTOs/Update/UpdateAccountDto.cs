using Common.API.DTOs.Update;

namespace AccountService.API.DTOs.Update;

public record UpdateAccountDto : UpdateBaseDto
{
    public Guid? GenderCode { get; set; }
    public string? Username { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Guid? CountryCode { get; set; }
    public Guid? StateCode { get; set; }
    public Guid? CityCode { get; set; }
    public string? Biography { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public decimal? Weight { get; set; }
    public decimal? Height { get; set; }
    public bool? Private { get; set; }
    public IFormFile? UploadImage { get; set; }
    public bool RemovedImage { get; set; }
}