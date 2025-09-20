using AccountService.Application.DTOs;
using AccountService.Application.DTOs.Create;
using AccountService.Application.DTOs.Update;
using AccountService.Domain.Entities;
using AutoMapper;

namespace AccountService.Infrastructure.Data.Configurations.Mapping;

public class SubregionEntityProfile : Profile
{
    public SubregionEntityProfile()
    {
        CreateMap<SubregionEntityDto, Subregion>().ReverseMap();
        CreateMap<CreateSubregionEntityDto, Subregion>().ReverseMap();
        CreateMap<UpdateSubregionEntityDto, Subregion>().ReverseMap();
    }
}