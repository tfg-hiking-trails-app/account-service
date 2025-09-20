using AccountService.Application.DTOs;
using AutoMapper;

namespace AccountService.API.DTOs.Mapping;

public class StateProfile : Profile
{
    public StateProfile()
    {
        CreateMap<StateDto, StateEntityDto>().ReverseMap();
        CreateMap<StateSummaryDto, StateEntityDto>().ReverseMap();
    }
}