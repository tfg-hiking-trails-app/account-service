using AccountService.Domain.Entities;
using Common.Domain.Interfaces;

namespace AccountService.Domain.Interfaces;

public interface IStateRepository : IRepository<State>
{
    IEnumerable<State> GetAllByCountry(int countryId);
    
    Task<IEnumerable<State>> GetAllByCountryAsync(int countryId);
}