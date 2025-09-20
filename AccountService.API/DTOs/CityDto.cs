using Common.API.DTOs;

namespace AccountService.API.DTOs;

public record CityDto : BaseDto
{
    public required string Name { get; set; }
    public int StateId { get; set; }
    public StateDto? State { get; set; }
    public required string StateCode { get; set; }
    public int CountryId { get; set; }
    public CountryDto? Country { get; set; }
    public required string CountryCode { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public string? Timezone { get; set; }
    public bool Flag { get; set; }
    public string? WikiDataId { get; set; }
}