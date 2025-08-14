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

[Route("api/[controller]")]
public class AccountController : AbstractController<AccountDto, CreateAccountDto, UpdateAccountDto, 
    AccountEntityDto, CreateAccountEntityDto, UpdateAccountEntityDto>
{
    public AccountController(IAccountService service, IMapper mapper) 
        : base(service, mapper)
    {
    }
    
}