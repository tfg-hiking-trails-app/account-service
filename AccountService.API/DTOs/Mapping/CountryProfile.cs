using AccountService.Application.DTOs;
using AutoMapper;

namespace AccountService.API.DTOs.Mapping;

public class CountryProfile : Profile
{
    public CountryProfile()
    {
        CreateMap<CountryDto, CountryEntityDto>().ReverseMap();
        CreateMap<CountrySummaryDto, CountryEntityDto>().ReverseMap();
    }
}