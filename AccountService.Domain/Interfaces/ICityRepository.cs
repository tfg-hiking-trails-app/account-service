using AccountService.Domain.Entities;
using Common.Domain.Interfaces;

namespace AccountService.Domain.Interfaces;

public interface ICityRepository : IRepository<City>
{
    IEnumerable<City> GetAllByState(Guid stateCode);
    
    Task<IEnumerable<City>> GetAllByStateAsync(Guid stateCode);
}