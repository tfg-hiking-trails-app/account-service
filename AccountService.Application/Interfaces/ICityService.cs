using AccountService.Application.DTOs;
using AccountService.Application.DTOs.Create;
using AccountService.Application.DTOs.Update;
using Common.Application.Interfaces;

namespace AccountService.Application.Interfaces;

public interface ICityService : IService<CityEntityDto, CreateCityEntityDto, UpdateCityEntityDto>
{
    IEnumerable<CityEntityDto> GetAllByState(Guid stateCode);
    
    Task<IEnumerable<CityEntityDto>> GetAllByStateAsync(Guid stateCode);
}