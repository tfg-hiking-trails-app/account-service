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
public class RegionController : AbstractReadController<RegionDto, RegionEntityDto, 
    CreateRegionEntityDto, UpdateRegionEntityDto>
{
    public RegionController(
        IRegionService service, 
        IMapper mapper) : base(service, mapper)
    {
    }
}