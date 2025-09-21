using AccountService.API.DTOs;
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
public class AccountController : AbstractReadController<AccountDto, AccountEntityDto, 
    CreateAccountEntityDto, UpdateAccountEntityDto>
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
    
    [HttpPut("{code:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AccountDto>> Update(Guid code, [FromForm] UpdateAccountDto updateDto)
    {
        try
        {
            UpdateAccountEntityDto updateEntityDto = Mapper.Map<UpdateAccountEntityDto>(updateDto);

            return Ok(await Service.UpdateAsync(code, updateEntityDto));
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

    [HttpGet("searcher")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public virtual async Task<ActionResult<IEnumerable<AccountDto>>> Searcher(
        [FromQuery] string search,
        [FromQuery] int numberResults)
    {
        if (string.IsNullOrWhiteSpace(search))
            return BadRequest("search is empty");

        IEnumerable<AccountEntityDto> result = await _accountService.SearcherAsync(search, numberResults);

        return Ok(_mapper.Map<IEnumerable<AccountDto>>(result));
    }
    
}