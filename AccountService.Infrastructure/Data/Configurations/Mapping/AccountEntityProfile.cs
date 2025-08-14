using AccountService.Application.DTOs;
using AccountService.Application.DTOs.Create;
using AccountService.Application.DTOs.Update;
using AccountService.Domain.Entities;
using AutoMapper;

namespace AccountService.Infrastructure.Data.Configurations.Mapping;

public class AccountEntityProfile : Profile
{
    public AccountEntityProfile()
    {
        CreateMap<AccountEntityDto, Account>().ReverseMap();
        CreateMap<CreateAccountEntityDto, Account>().ReverseMap();
        CreateMap<UpdateAccountEntityDto, Account>().ReverseMap();
    }
}