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
            .AsNoTracking()
            .Include(a => a.Gender)
            .Include(a => a.Following)
            .Include(a => a.Followers)
            .AsSplitQuery()
            .ToList();
    }

    public override async Task<IEnumerable<Account>> GetAllAsync()
    {
        return await Entity
            .AsNoTracking()
            .Include(a => a.Gender)
            .Include(a => a.Following)
            .Include(a => a.Followers)
            .AsSplitQuery()
            .ToListAsync();
    }
    
    public override async Task<IPaged<Account>> GetPagedAsync(
        FilterData filter, 
        CancellationToken cancellationToken)
    {
        return await Entity
            .AsNoTracking()
            .Include(a => a.Gender)
            .Include(a => a.Following)
            .Include(a => a.Followers)
            .AsSplitQuery()
            .ToPageAsync(filter, cancellationToken);
    }

    public override Account? Get(int id)
    {
        return Entity
            .Include(a => a.Gender)
            .Include(a => a.Following)
            .Include(a => a.Followers)
            .AsSplitQuery()
            .FirstOrDefault(a => a.Id == id);
    }

    public override async Task<Account?> GetAsync(int id)
    {
        return await Entity
            .Include(a => a.Gender)
            .Include(a => a.Following)
            .Include(a => a.Followers)
            .AsSplitQuery()
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public override Account? GetByCode(Guid code)
    {
        return Entity
            .Include(a => a.Gender)
            .Include(a => a.Following)
            .Include(a => a.Followers)
            .AsSplitQuery()
            .FirstOrDefault(a => a.Code == code);
    }

    public override async Task<Account?> GetByCodeAsync(Guid code)
    {
        return await Entity
            .Include(a => a.Gender)
            .Include(a => a.Following)
            .Include(a => a.Followers)
            .AsSplitQuery()
            .FirstOrDefaultAsync(a => a.Code == code);
    }

    public Account? GetByUsername(string username)
    {
        return Entity
            .Include(a => a.Gender)
            .Include(a => a.Following)
            .Include(a => a.Followers)
            .AsSplitQuery()
            .FirstOrDefault(a => a.Username.Equals(username));
    }

    public async Task<Account?> GetByUsernameAsync(string username)
    {
        return await Entity
            .Include(a => a.Gender)
            .Include(a => a.Following)
            .Include(a => a.Followers)
            .AsSplitQuery()
            .FirstOrDefaultAsync(a => a.Username.Equals(username));
    }

    public async Task<IEnumerable<Account>> SearcherAsync(string search, int numberResults)
    {
        return await Entity
            .AsNoTracking()
            .Include(a => a.Gender)
            .Include(a => a.Following)
            .Include(a => a.Followers)
            .AsSplitQuery()
            .Where(a => a.Username.ToLower().Contains(search.ToLower()) ||
                        (a.FirstName != null && a.FirstName.ToLower().Contains(search.ToLower())) ||
                        (a.LastName != null && a.LastName.ToLower().Contains(search.ToLower())))
            .OrderBy(a => a.Username)
            .ThenBy(a => a.FirstName)
            .ThenBy(a => a.LastName)
            .Take(numberResults)
            .ToListAsync();
    }
    
}