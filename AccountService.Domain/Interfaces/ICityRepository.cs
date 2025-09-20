using AccountService.Domain.Entities;
using Common.Domain.Interfaces;

namespace AccountService.Domain.Interfaces;

public interface ICityRepository : IRepository<City>
{
    IEnumerable<City> GetAllByState(int stateId);
    
    Task<IEnumerable<City>> GetAllByStateAsync(int stateId);
}