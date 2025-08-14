using AccountService.API.DTOs;
using AccountService.API.DTOs.Create;
using AccountService.API.DTOs.Update;
using AccountService.Application.DTOs;
using AccountService.Application.DTOs.Create;
using AccountService.Application.DTOs.Update;
using AccountService.Application.Interfaces;
using AutoMapper;
using Common.API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.API.Controllers;

[Route("api/account-follow")]
public class AccountFollowController : AbstractController<AccountFollowDto, CreateAccountFollowDto, UpdateAccountFollowDto, 
    AccountFollowEntityDto, CreateAccountFollowEntityDto, UpdateAccountFollowEntityDto>
{
    public AccountFollowController(IAccountFollowService service, IMapper mapper) 
        : base(service, mapper)
    {
    }
    
}