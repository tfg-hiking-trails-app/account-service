using AccountService.Application.DTOs;
using AccountService.Application.DTOs.Create;
using AccountService.Application.DTOs.Update;
using AccountService.Domain.Entities;
using AutoMapper;

namespace AccountService.Infrastructure.Data.Configurations.Mapping;

public class AccountFollowEntityProfile : Profile
{
    public AccountFollowEntityProfile()
    {
        CreateMap<AccountFollowEntityDto, AccountFollow>().ReverseMap();
        CreateMap<CreateAccountFollowEntityDto, AccountFollow>().ReverseMap();
        CreateMap<UpdateAccountFollowEntityDto, AccountFollow>()
            .ForAllMembers(opt => opt
                .Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<AccountFollow, UpdateAccountFollowEntityDto>();
    }
}