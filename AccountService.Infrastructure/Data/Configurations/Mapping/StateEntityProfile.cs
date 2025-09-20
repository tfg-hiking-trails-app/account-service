using AccountService.Application.DTOs;
using AccountService.Application.DTOs.Create;
using AccountService.Application.DTOs.Update;
using AccountService.Domain.Entities;
using AutoMapper;

namespace AccountService.Infrastructure.Data.Configurations.Mapping;

public class StateEntityProfile : Profile
{
    public StateEntityProfile()
    {
        CreateMap<StateEntityDto, State>().ReverseMap();
        CreateMap<CreateStateEntityDto, State>().ReverseMap();
        CreateMap<UpdateStateEntityDto, State>().ReverseMap();
    }
}