using AccountService.API.DTOs.Create;
using AccountService.API.DTOs.Update;
using AccountService.Application.DTOs;
using AccountService.Application.DTOs.Create;
using AccountService.Application.DTOs.Update;
using AutoMapper;

namespace AccountService.API.DTOs.Mapping;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<AccountDto, AccountEntityDto>().ReverseMap();
        CreateMap<CreateAccountDto, CreateAccountEntityDto>().ReverseMap();
        CreateMap<UpdateAccountDto, UpdateAccountEntityDto>().ReverseMap();
    }
}