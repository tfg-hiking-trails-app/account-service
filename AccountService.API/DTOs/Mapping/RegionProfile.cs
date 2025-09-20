using AccountService.Application.DTOs;
using AutoMapper;

namespace AccountService.API.DTOs.Mapping;

public class RegionProfile : Profile
{
    public RegionProfile()
    {
        CreateMap<RegionEntityDto, RegionDto>().ReverseMap();
    }
}