using AccountService.Domain.Entities;
using Common.Domain.Filter;
using Common.Domain.Interfaces;

namespace AccountService.Domain.Interfaces;

public interface IAccountFollowRepository : IRepository<AccountFollow>
{
    Task<IPaged<AccountFollow>> GetFollowersByAccount(int accountId, FilterData filter, CancellationToken cancellationToken);
    Task<IEnumerable<AccountFollow>> GetAllFollowersByAccount(int accountId);
    
    Task<IPaged<AccountFollow>> GetFollowedByAccount(int accountId, FilterData filter, CancellationToken cancellationToken);
    Task<IEnumerable<AccountFollow>> GetAllFollowedByAccount(int accountId);

    Task<int> GetFollowersCountByAccount(int accountId);
    Task<int> GetFollowedCountByAccount(int accountId);
}