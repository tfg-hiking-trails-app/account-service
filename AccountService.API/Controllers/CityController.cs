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
public class CityController : AbstractReadController<CityDto, CityEntityDto, 
    CreateCityEntityDto, UpdateCityEntityDto>
{
    private readonly ICityService _cityService;
    
    public CityController(
        ICityService service, 
        IMapper mapper) : base(service, mapper)
    {
        _cityService = service;
    }
    
    [HttpGet("state/{stateId:int}/all/summary")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CitySummaryDto>>> GetAllSummaryByState(
        [FromRoute][Range(1, int.MaxValue)] 
        int stateId)
    {
        IEnumerable<CityEntityDto> list = await _cityService.GetAllByStateAsync(stateId);
        
        return Ok(Mapper.Map<IEnumerable<CitySummaryDto>>(list));
    }
    
}