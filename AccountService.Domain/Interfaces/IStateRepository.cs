using AccountService.Domain.Entities;
using Common.Domain.Interfaces;

namespace AccountService.Domain.Interfaces;

public interface IStateRepository : IRepository<State>
{
    IEnumerable<State> GetAllByCountry(Guid countryCode);
    
    Task<IEnumerable<State>> GetAllByCountryAsync(Guid countryCode);
}