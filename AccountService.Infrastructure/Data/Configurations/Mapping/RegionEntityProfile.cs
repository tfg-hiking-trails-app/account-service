using AccountService.Application.DTOs;
using AccountService.Application.DTOs.Create;
using AccountService.Application.DTOs.Update;
using AccountService.Domain.Entities;
using AutoMapper;

namespace AccountService.Infrastructure.Data.Configurations.Mapping;

public class RegionEntityProfile : Profile
{
    public RegionEntityProfile()
    {
        CreateMap<RegionEntityDto, Region>().ReverseMap();
        CreateMap<CreateRegionEntityDto, Region>().ReverseMap();
        CreateMap<UpdateRegionEntityDto, Region>().ReverseMap();
    }
}