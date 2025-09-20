using AccountService.Application.DTOs;
using AutoMapper;

namespace AccountService.API.DTOs.Mapping;

public class SubregionProfile : Profile
{
    public SubregionProfile()
    {
        CreateMap<SubregionDto, SubregionEntityDto>().ReverseMap();
    }
}