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
    
    [HttpGet("state/{stateCode:guid}/all/summary")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CitySummaryDto>>> GetAllSummaryByState(Guid stateCode)
    {
        IEnumerable<CityEntityDto> list = await _cityService.GetAllByStateAsync(stateCode);
        
        return Ok(Mapper.Map<IEnumerable<CitySummaryDto>>(list));
    }
    
}