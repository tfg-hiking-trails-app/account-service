using System.ComponentModel.DataAnnotations;
using AccountService.API.DTOs;
using AccountService.Application.DTOs;
using AccountService.Application.DTOs.Create;
using AccountService.Application.DTOs.Update;
using AccountService.Application.Interfaces;
using AutoMapper;
using Common.API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.API.Controllers;

[Route("api/[controller]")]
public class StateController : AbstractReadController<StateDto, StateEntityDto, 
    CreateStateEntityDto, UpdateStateEntityDto>
{
    private readonly IStateService _stateService;
    
    public StateController(
        IStateService service, 
        IMapper mapper) : base(service, mapper)
    {
        _stateService = service;
    }
    
    [HttpGet("country/{countryId:int}/all/summary")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<StateSummaryDto>>> GetAllSummaryByCountry(
        [FromRoute][Range(1, int.MaxValue)] 
        int countryId)
    {
        IEnumerable<StateEntityDto> list = await _stateService.GetAllByCountryAsync(countryId);
        
        return Ok(Mapper.Map<IEnumerable<StateSummaryDto>>(list));
    }
    
}