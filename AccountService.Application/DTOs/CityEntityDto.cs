using Common.Application.DTOs;

namespace AccountService.Application.DTOs;

public record CityEntityDto : BaseEntityDto
{
    public required string Name { get; set; }
    public int StateId { get; set; }
    public StateEntityDto? State { get; set; }
    public required string StateCode { get; set; }
    public int CountryId { get; set; }
    public CountryEntityDto? Country { get; set; }
    public required string CountryCode { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public string? Timezone { get; set; }
    public bool Flag { get; set; }
    public string? WikiDataId { get; set; }
}