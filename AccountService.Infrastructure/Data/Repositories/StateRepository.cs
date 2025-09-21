using AccountService.Domain.Entities;
using AccountService.Domain.Interfaces;
using Common.Application.Extensions;
using Common.Domain.Filter;
using Common.Domain.Interfaces;
using Common.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Infrastructure.Data.Repositories;

public class StateRepository : AbstractRepository<State>, IStateRepository
{
    public StateRepository(AccountServiceDbContext dbContext) : base(dbContext)
    {
    }
    
    public override IEnumerable<State> GetAll()
    {
        return Entity
            .Include(s => s.Country)
            .Include(s => s.Cities)
            .ToList();
    }

    public override async Task<IEnumerable<State>> GetAllAsync()
    {
        return await Entity
            .Include(s => s.Country)
            .Include(s => s.Cities)
            .ToListAsync();
    }
    
    public override async Task<IPaged<State>> GetPagedAsync(
        FilterData filter, 
        CancellationToken cancellationToken)
    {
        return await Entity
            .Include(s => s.Country)
            .Include(s => s.Cities)
            .ToPageAsync(filter, cancellationToken);
    }

    public override State? Get(int id)
    {
        return Entity
            .Include(s => s.Country)
            .Include(s => s.Cities)
            .FirstOrDefault(s => s.Id == id);
    }

    public override async Task<State?> GetAsync(int id)
    {
        return await Entity
            .Include(s => s.Country)
            .Include(s => s.Cities)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public override State? GetByCode(Guid code)
    {
        return Entity
            .Include(s => s.Country)
            .Include(s => s.Cities)
            .FirstOrDefault(s => s.Code == code);
    }

    public override async Task<State?> GetByCodeAsync(Guid code)
    {
        return await Entity
            .Include(s => s.Country)
            .Include(s => s.Cities)
            .FirstOrDefaultAsync(s => s.Code == code);
    }

    public IEnumerable<State> GetAllByCountry(Guid countryCode)
    {
        return Entity
            .AsNoTracking()
            .Where(s => s.Country.Code == countryCode && s.Cities.Any())
            .Include(s => s.Country)
            .Include(s => s.Cities)
            .AsSplitQuery()
            .OrderBy(s => s.Name)
            .ToList();
    }

    public async Task<IEnumerable<State>> GetAllByCountryAsync(Guid countryCode)
    {
        return await Entity
            .AsNoTracking()
            .Where(s => s.Country.Code == countryCode && s.Cities.Any())
            .Include(s => s.Country)
            .Include(s => s.Cities)
            .AsSplitQuery()
            .OrderBy(s => s.Name)
            .ToListAsync();
    }
    
}