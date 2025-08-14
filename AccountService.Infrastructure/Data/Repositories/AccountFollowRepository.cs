using AccountService.Domain.Entities;
using AccountService.Domain.Interfaces;
using Common.Application.Extensions;
using Common.Domain.Filter;
using Common.Domain.Interfaces;
using Common.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Infrastructure.Data.Repositories;

public class AccountFollowRepository : AbstractRepository<AccountFollow>, IAccountFollowRepository
{
    public AccountFollowRepository(AccountServiceDbContext dbContext) : base(dbContext)
    {
    }
    
    public override IEnumerable<AccountFollow> GetAll()
    {
        return Entity
            .Include(a => a.FollowerAccount)
            .Include(a => a.FollowedAccount)
            .Include(a => a.FollowerAccount.Gender)
            .Include(a => a.FollowedAccount.Gender)
            .ToList();
    }

    public override async Task<IEnumerable<AccountFollow>> GetAllAsync()
    {
        return await Entity
            .Include(a => a.FollowerAccount)
            .Include(a => a.FollowedAccount)
            .Include(a => a.FollowerAccount.Gender)
            .Include(a => a.FollowedAccount.Gender)
            .ToListAsync();    }
    
    public override async Task<IPaged<AccountFollow>> GetPagedAsync(
        FilterData filter, 
        CancellationToken cancellationToken)
    {
        return await Entity
            .Include(a => a.FollowerAccount)
            .Include(a => a.FollowedAccount)
            .Include(a => a.FollowerAccount.Gender)
            .Include(a => a.FollowedAccount.Gender)
            .ToPageAsync(filter, cancellationToken);
    }

    public override AccountFollow? Get(int id)
    {
        return Entity
            .Include(a => a.FollowerAccount)
            .Include(a => a.FollowedAccount)
            .Include(a => a.FollowerAccount.Gender)
            .Include(a => a.FollowedAccount.Gender)
            .FirstOrDefault(a => a.Id == id);
    }

    public override async Task<AccountFollow?> GetAsync(int id)
    {
        return await Entity
            .Include(a => a.FollowerAccount)
            .Include(a => a.FollowedAccount)
            .Include(a => a.FollowerAccount.Gender)
            .Include(a => a.FollowedAccount.Gender)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public override AccountFollow? GetByCode(Guid code)
    {
        return Entity
            .Include(a => a.FollowerAccount)
            .Include(a => a.FollowedAccount)
            .Include(a => a.FollowerAccount.Gender)
            .Include(a => a.FollowedAccount.Gender)
            .FirstOrDefault(a => a.Code == code);
    }

    public override async Task<AccountFollow?> GetByCodeAsync(Guid code)
    {
        return await Entity
            .Include(a => a.FollowerAccount)
            .Include(a => a.FollowedAccount)
            .Include(a => a.FollowerAccount.Gender)
            .Include(a => a.FollowedAccount.Gender)
            .FirstOrDefaultAsync(a => a.Code == code);
    }
    
}