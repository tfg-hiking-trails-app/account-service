using AccountService.Application.DTOs;
using AccountService.Application.DTOs.Create;
using AccountService.Application.DTOs.Update;
using AccountService.Domain.Entities;
using AutoMapper;

namespace AccountService.Infrastructure.Data.Configurations.Mapping;

public class GenderEntityProfile : Profile
{
    public GenderEntityProfile()
    {
        CreateMap<GenderEntityDto, Gender>().ReverseMap();
        CreateMap<CreateGenderEntityDto, Gender>().ReverseMap();
        CreateMap<UpdateGenderEntityDto, Gender>()
            .ForAllMembers(opt => opt
                .Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<Gender, UpdateGenderEntityDto>();
    }
}