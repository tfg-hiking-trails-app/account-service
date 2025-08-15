using AccountService.API.DTOs;
using AccountService.API.DTOs.Create;
using AccountService.API.DTOs.Update;
using AccountService.Application.DTOs;
using AccountService.Application.DTOs.Create;
using AccountService.Application.DTOs.Update;
using AccountService.Application.Interfaces;
using AutoMapper;
using Common.API.Controllers;
using Common.API.DTOs.Filter;
using Common.API.Utils;
using Common.Application.DTOs.Filter;
using Common.Application.Pagination;
using Common.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.API.Controllers;

[Route("api/account-follow")]
public class AccountFollowController : AbstractController<AccountFollowDto, CreateAccountFollowDto, UpdateAccountFollowDto, 
    AccountFollowEntityDto, CreateAccountFollowEntityDto, UpdateAccountFollowEntityDto>
{
    private readonly IAccountFollowService _accountFollowService;
    private readonly IMapper _mapper;
    
    public AccountFollowController(
        IAccountFollowService accountFollowService,
        IMapper mapper) 
        : base(accountFollowService, mapper)
    {
        _accountFollowService = accountFollowService;
        _mapper = mapper;
    }

    /// <summary>
    /// Obtiene todas las cuentas que siguen a la cuenta especificada
    /// </summary>
    [HttpGet("followers/{accountCode:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Page<AccountDto>>> GetFollowersByAccountCode(
        Guid accountCode,
        CancellationToken cancellationToken,
        [FromQuery] int pageNumber = Pagination.PageNumber,
        [FromQuery] int pageSize = Pagination.PageSize,
        [FromQuery] string sortField = Pagination.SortField,
        [FromQuery] string sortDirection = Pagination.SortDirection)
    {
        try
        {
            FilterDto filter = new FilterDto(pageNumber, pageSize, sortField, sortDirection);
            
            Page<AccountEntityDto> followers = await _accountFollowService.GetFollowersByAccountCode(
                accountCode, _mapper.Map<FilterEntityDto>(filter), cancellationToken);
            
            return Ok(_mapper.Map<Page<AccountDto>>(followers));
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

    /// <summary>
    /// Obtiene todas las cuentas a las que sigue la cuenta especificada
    /// </summary>
    [HttpGet("followed/{accountCode:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Page<AccountDto>>> GetFollowedByAccountCode(
        Guid accountCode,
        CancellationToken cancellationToken,
        [FromQuery] int pageNumber = Pagination.PageNumber,
        [FromQuery] int pageSize = Pagination.PageSize,
        [FromQuery] string sortField = Pagination.SortField,
        [FromQuery] string sortDirection = Pagination.SortDirection)
    {
        try
        {
            FilterDto filter = new FilterDto(pageNumber, pageSize, sortField, sortDirection);
            
            Page<AccountEntityDto> followed = await _accountFollowService.GetFollowedByAccountCode(
                accountCode, _mapper.Map<FilterEntityDto>(filter), cancellationToken);
            
            return Ok(_mapper.Map<Page<AccountDto>>(followed));
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