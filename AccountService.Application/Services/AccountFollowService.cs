using AccountService.Application.DTOs;
using AccountService.Application.DTOs.Create;
using AccountService.Application.DTOs.Update;
using AccountService.Application.Interfaces;
using AccountService.Domain.Entities;
using AccountService.Domain.Interfaces;
using AutoMapper;
using Common.Application.Services;
using Common.Application.Utils;

namespace AccountService.Application.Services;

public class AccountFollowService : AbstractService<AccountFollow, AccountFollowEntityDto, CreateAccountFollowEntityDto, UpdateAccountFollowEntityDto>, 
    IAccountFollowService
{
    public AccountFollowService(IAccountFollowRepository repository, IMapper mapper) : 
        base(repository, mapper)
    {
    }

    protected override void CheckDataValidity(CreateAccountFollowEntityDto createEntityDto)
    {
        if (createEntityDto.FollowerAccountCode.HasValue)
            Validator.CheckGuid(createEntityDto.FollowerAccountCode.Value);
        
        if (createEntityDto.FollowedAccountCode.HasValue)
            Validator.CheckGuid(createEntityDto.FollowedAccountCode.Value);
    }
    
}