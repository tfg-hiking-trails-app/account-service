using AccountService.API.DTOs;
using AccountService.API.DTOs.Create;
using AccountService.API.DTOs.Update;
using AccountService.Application.DTOs;
using AccountService.Application.DTOs.Create;
using AccountService.Application.DTOs.Update;
using AccountService.Application.Interfaces;
using AutoMapper;
using Common.API.Controllers;
using Common.API.Extensions;
using Common.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.API.Controllers;

[Route("api/[controller]")]
public class AccountController : AbstractController<AccountDto, CreateAccountDto, UpdateAccountDto, 
    AccountEntityDto, CreateAccountEntityDto, UpdateAccountEntityDto>
{
    private readonly IAccountService _accountService;
    private readonly IMapper _mapper;
    
    public AccountController(
        IAccountService service, 
        IMapper mapper) : base(service, mapper)
    {
        _accountService = service;
        _mapper = mapper;
    }
    
    [HttpGet("logged")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public virtual async Task<ActionResult<AccountDto>> GetLogged()
    {
        try
        {
            string? userCode = Request.GetUserCode();

            if (userCode is null)
                return Unauthorized();
            
            AccountEntityDto entityDto = await _accountService.GetByCodeAsync(new Guid(userCode));

            return Ok(_mapper.Map<AccountDto>(entityDto));
        }
        catch (NotFoundEntityException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
}