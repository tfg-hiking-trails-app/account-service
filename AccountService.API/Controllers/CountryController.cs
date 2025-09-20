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
public class CountryController : AbstractReadController<CountryDto, CountryEntityDto, 
    CreateCountryEntityDto, UpdateCountryEntityDto>
{
    public CountryController(ICountryService service, IMapper mapper) : base(service, mapper)
    {
    }

    [HttpGet("all/summary")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CountrySummaryDto>>> GetAllSummary()
    {
        IEnumerable<CountryEntityDto> list = await Service.GetAllAsync();
        
        return Ok(Mapper.Map<IEnumerable<CountrySummaryDto>>(list));
    }
    
}