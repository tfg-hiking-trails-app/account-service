using AccountService.Application.DTOs;
using AccountService.Application.DTOs.Create;
using AccountService.Application.DTOs.Update;
using Common.Application.Interfaces;

namespace AccountService.Application.Interfaces;

public interface IStateService : IService<StateEntityDto, CreateStateEntityDto, UpdateStateEntityDto>
{
    IEnumerable<StateEntityDto> GetAllByCountry(Guid countryCode);
    
    Task<IEnumerable<StateEntityDto>> GetAllByCountryAsync(Guid countryCode);
}