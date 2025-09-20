using AccountService.Application.DTOs;
using AutoMapper;

namespace AccountService.API.DTOs.Mapping;

public class CityProfile : Profile
{
    public CityProfile()
    {
        CreateMap<CityDto, CityEntityDto>().ReverseMap();
        CreateMap<CitySummaryDto, CityEntityDto>().ReverseMap();
    }
}