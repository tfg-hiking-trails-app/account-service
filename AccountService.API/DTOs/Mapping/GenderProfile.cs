using AccountService.API.DTOs.Create;
using AccountService.API.DTOs.Update;
using AccountService.Application.DTOs;
using AccountService.Application.DTOs.Create;
using AccountService.Application.DTOs.Update;
using AutoMapper;

namespace AccountService.API.DTOs.Mapping;

public class GenderProfile : Profile
{
    public GenderProfile()
    {
        CreateMap<GenderDto, GenderEntityDto>().ReverseMap();
        CreateMap<CreateGenderDto, CreateGenderEntityDto>().ReverseMap();
        CreateMap<UpdateGenderDto, UpdateGenderEntityDto>().ReverseMap();
    }
}