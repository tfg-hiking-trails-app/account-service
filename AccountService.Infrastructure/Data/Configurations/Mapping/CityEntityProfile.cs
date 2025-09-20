using AccountService.Application.DTOs;
using AccountService.Application.DTOs.Create;
using AccountService.Application.DTOs.Update;
using AccountService.Domain.Entities;
using AutoMapper;

namespace AccountService.Infrastructure.Data.Configurations.Mapping;

public class CityEntityProfile : Profile
{
    public CityEntityProfile()
    {
        CreateMap<CityEntityDto, City>().ReverseMap();
        CreateMap<CreateCityEntityDto, City>().ReverseMap();
        CreateMap<UpdateCityEntityDto, City>().ReverseMap();
    }
}