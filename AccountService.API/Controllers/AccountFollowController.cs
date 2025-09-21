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
public class AccountFollowController : AbstractCrudController<AccountFollowDto, CreateAccountFollowDto, UpdateAccountFollowDto, 
    AccountFollowEntityDto, CreateAccountFollowEntityDto, UpdateAccountFollowEntityDto>
{
    private readonly IAccountFollowService _service;
    private readonly IMapper _mapper;
    
    public AccountFollowController(
        IAccountFollowService service,
        IMapper mapper) 
        : base(service, mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    
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
            
            Page<AccountEntityDto> followers = await _service.GetFollowersByAccountCode(
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
    
    [HttpGet("followers/{accountCode:guid}/all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AccountDto>>> GetAllFollowersByAccountCode(Guid accountCode)
    {
        try
        {
            IEnumerable<AccountEntityDto> followers = await _service.GetAllFollowersByAccountCode(accountCode);
            
            return Ok(_mapper.Map<IEnumerable<AccountDto>>(followers));
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
            
            Page<AccountEntityDto> followed = await _service.GetFollowedByAccountCode(
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
    
    [HttpGet("followed/{accountCode:guid}/all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AccountDto>>> GetAllFollowedByAccountCode(Guid accountCode)
    {
        try
        {
            IEnumerable<AccountEntityDto> followed = await _service.GetAllFollowedByAccountCode(accountCode);
            
            return Ok(_mapper.Map<IEnumerable<AccountDto>>(followed));
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

    [HttpGet("followers/{accountCode:guid}/count")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> GetFollowersCountByAccountCode(Guid accountCode)
    {
        try
        {
            return Ok(await _service.GetFollowersCountByAccountCode(accountCode));
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
    
    [HttpGet("followed/{accountCode:guid}/count")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<int>> GetFollowedCountByAccountCode(Guid accountCode)
    {
        try
        {
            return Ok(await _service.GetFollowedCountByAccountCode(accountCode));
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