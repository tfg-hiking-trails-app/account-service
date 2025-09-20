using AccountService.Application.DTOs;
using AccountService.Application.DTOs.Create;
using AccountService.Application.DTOs.Update;
using AccountService.Application.Interfaces;
using AccountService.Domain.Entities;
using AccountService.Domain.Interfaces;
using AutoMapper;
using Common.Application.Services;

namespace AccountService.Application.Services;

public class CityService : AbstractService<City, CityEntityDto, CreateCityEntityDto, UpdateCityEntityDto>, 
    ICityService
{
    private readonly ICityRepository _cityRepository;
    
    public CityService(
        ICityRepository repository, 
        IMapper mapper) : base(repository, mapper)
    {
        _cityRepository = repository;
    }

    public IEnumerable<CityEntityDto> GetAllByState(int stateId)
    {
        IEnumerable<City> result = _cityRepository.GetAllByState(stateId);
        
        return Mapper.Map<IEnumerable<CityEntityDto>>(result);
    }

    public async Task<IEnumerable<CityEntityDto>> GetAllByStateAsync(int stateId)
    {
        IEnumerable<City> result =  await _cityRepository.GetAllByStateAsync(stateId);
        
        return Mapper.Map<IEnumerable<CityEntityDto>>(result);
    }
    
    protected override void CheckDataValidity(CreateCityEntityDto createEntityDto)
    {
        throw new NotImplementedException();
    }
}