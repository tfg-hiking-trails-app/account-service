using AccountService.Application.DTOs;
using AccountService.Application.DTOs.Create;
using AccountService.Application.DTOs.Update;
using AccountService.Application.Interfaces;
using AccountService.Domain.Entities;
using AccountService.Domain.Interfaces;
using AutoMapper;
using Common.Application.Services;

namespace AccountService.Application.Services;

public class CountryService : AbstractService<Country, CountryEntityDto, CreateCountryEntityDto, UpdateCountryEntityDto>, 
    ICountryService
{
    public CountryService(ICountryRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    protected override void CheckDataValidity(CreateCountryEntityDto createEntityDto)
    {
        throw new NotImplementedException();
    }
}