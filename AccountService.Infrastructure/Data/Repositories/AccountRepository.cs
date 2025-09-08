using AccountService.Domain.Entities;
using AccountService.Domain.Interfaces;
using Common.Application.Extensions;
using Common.Domain.Filter;
using Common.Domain.Interfaces;
using Common.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Infrastructure.Data.Repositories;

public class AccountRepository : AbstractRepository<Account>, IAccountRepository
{
    public AccountRepository(AccountServiceDbContext dbContext) : base(dbContext)
    {
    }
    
    public override IEnumerable<Account> GetAll()
    {
        return Entity
            .Include(a => a.Gender)
            .Include(a => a.Following)
            .Include(a => a.Followers)
            .ToList();
    }

    public override async Task<IEnumerable<Account>> GetAllAsync()
    {
        return await Entity
            .Include(a => a.Gender)
            .Include(a => a.Following)
            .Include(a => a.Followers)
            .ToListAsync();    }
    
    public override async Task<IPaged<Account>> GetPagedAsync(
        FilterData filter, 
        CancellationToken cancellationToken)
    {
        return await Entity
            .Include(a => a.Gender)
            .Include(a => a.Following)
            .Include(a => a.Followers)
            .ToPageAsync(filter, cancellationToken);
    }

    public override Account? Get(int id)
    {
        return Entity
            .Include(a => a.Gender)
            .Include(a => a.Following)
            .Include(a => a.Followers)
            .FirstOrDefault(a => a.Id == id);
    }

    public override async Task<Account?> GetAsync(int id)
    {
        return await Entity
            .Include(a => a.Gender)
            .Include(a => a.Following)
            .Include(a => a.Followers)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public override Account? GetByCode(Guid code)
    {
        return Entity
            .Include(a => a.Gender)
            .Include(a => a.Following)
            .Include(a => a.Followers)
            .FirstOrDefault(a => a.Code == code);
    }

    public override async Task<Account?> GetByCodeAsync(Guid code)
    {
        return await Entity
            .Include(a => a.Gender)
            .Include(a => a.Following)
            .Include(a => a.Followers)
            .FirstOrDefaultAsync(a => a.Code == code);
    }

    public Account? GetByUsername(string username)
    {
        return Entity
            .Include(a => a.Gender)
            .Include(a => a.Following)
            .Include(a => a.Followers)
            .FirstOrDefault(a => a.Username.Equals(username));
    }

    public async Task<Account?> GetByUsernameAsync(string username)
    {
        return await Entity
            .Include(a => a.Gender)
            .Include(a => a.Following)
            .Include(a => a.Followers)
            .FirstOrDefaultAsync(a => a.Username.Equals(username));
    }
}