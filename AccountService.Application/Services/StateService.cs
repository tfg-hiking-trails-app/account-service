using AccountService.Application.DTOs;
using AccountService.Application.DTOs.Create;
using AccountService.Application.DTOs.Update;
using AccountService.Application.Interfaces;
using AccountService.Domain.Entities;
using AccountService.Domain.Interfaces;
using AutoMapper;
using Common.Application.Services;

namespace AccountService.Application.Services;

public class StateService : AbstractService<State, StateEntityDto, CreateStateEntityDto, UpdateStateEntityDto>, 
    IStateService
{
    private readonly IStateRepository _repository;
    
    public StateService(
        IStateRepository repository, 
        IMapper mapper) : base(repository, mapper)
    {
        _repository = repository;
    }
    
    public IEnumerable<StateEntityDto> GetAllByCountry(Guid countryCode)
    {
        IEnumerable<State> result = _repository.GetAllByCountry(countryCode);
        
        return Mapper.Map<IEnumerable<StateEntityDto>>(result);
    }

    public async Task<IEnumerable<StateEntityDto>> GetAllByCountryAsync(Guid countryCode)
    {
        IEnumerable<State> result =  await _repository.GetAllByCountryAsync(countryCode);
        
        return Mapper.Map<IEnumerable<StateEntityDto>>(result);
    }

    protected override void CheckDataValidity(CreateStateEntityDto createEntityDto)
    {
        throw new NotImplementedException();
    }
}