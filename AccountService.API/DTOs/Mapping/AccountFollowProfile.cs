using AccountService.API.DTOs.Create;
using AccountService.API.DTOs.Update;
using AccountService.Application.DTOs;
using AccountService.Application.DTOs.Create;
using AccountService.Application.DTOs.Update;
using AutoMapper;

namespace AccountService.API.DTOs.Mapping;

public class AccountFollowProfile : Profile
{
    public AccountFollowProfile()
    {
        CreateMap<AccountFollowDto, AccountFollowEntityDto>().ReverseMap();
        CreateMap<CreateAccountFollowDto, CreateAccountFollowEntityDto>().ReverseMap();
        CreateMap<UpdateAccountFollowDto, UpdateAccountFollowEntityDto>().ReverseMap();
    }
}