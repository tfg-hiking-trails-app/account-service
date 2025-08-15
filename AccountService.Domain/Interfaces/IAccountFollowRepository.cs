using AccountService.Domain.Entities;
using Common.Domain.Filter;
using Common.Domain.Interfaces;

namespace AccountService.Domain.Interfaces;

public interface IAccountFollowRepository : IRepository<AccountFollow>
{
    Task<IPaged<AccountFollow>> GetFollowersByAccountCode(int accountId,
        FilterData filter, CancellationToken cancellationToken);
    
    Task<IPaged<AccountFollow>> GetFollowedByAccountCode(int accountId,
        FilterData filter, CancellationToken cancellationToken);
}