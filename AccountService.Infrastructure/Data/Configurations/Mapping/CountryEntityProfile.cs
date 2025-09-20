using AccountService.Application.DTOs;
using AccountService.Application.DTOs.Create;
using AccountService.Application.DTOs.Update;
using AccountService.Domain.Entities;
using AutoMapper;

namespace AccountService.Infrastructure.Data.Configurations.Mapping;

public class CountryEntityProfile : Profile
{
    public CountryEntityProfile()
    {
        CreateMap<CountryEntityDto, Country>().ReverseMap();
        CreateMap<CreateCountryEntityDto, Country>().ReverseMap();
        CreateMap<UpdateCountryEntityDto, Country>().ReverseMap();
    }
}