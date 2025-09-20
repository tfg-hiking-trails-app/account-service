using AccountService.Domain.Entities;
using AccountService.Domain.Interfaces;
using Common.Application.Extensions;
using Common.Domain.Filter;
using Common.Domain.Interfaces;
using Common.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Infrastructure.Data.Repositories;

public class CityRepository : AbstractRepository<City>, ICityRepository
{
    public CityRepository(AccountServiceDbContext dbContext) : base(dbContext)
    {
    }
    
    public override IEnumerable<City> GetAll()
    {
        return Entity
            .Include(c => c.State)
            .Include(c => c.Country)
            .ToList();
    }

    public override async Task<IEnumerable<City>> GetAllAsync()
    {
        return await Entity
            .Include(c => c.State)
            .Include(c => c.Country)
            .ToListAsync();    }
    
    public override async Task<IPaged<City>> GetPagedAsync(
        FilterData filter, 
        CancellationToken cancellationToken)
    {
        return await Entity
            .Include(c => c.State)
            .Include(c => c.Country)
            .ToPageAsync(filter, cancellationToken);
    }

    public override City? Get(int id)
    {
        return Entity
            .Include(c => c.State)
            .Include(c => c.Country)
            .FirstOrDefault(c => c.Id == id);
    }

    public override async Task<City?> GetAsync(int id)
    {
        return await Entity
            .Include(c => c.State)
            .Include(c => c.Country)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public override City? GetByCode(Guid code)
    {
        return Entity
            .Include(c => c.State)
            .Include(c => c.Country)
            .FirstOrDefault(c => c.Code == code);
    }

    public override async Task<City?> GetByCodeAsync(Guid code)
    {
        return await Entity
            .Include(c => c.State)
            .Include(c => c.Country)
            .FirstOrDefaultAsync(c => c.Code == code);
    }

    public IEnumerable<City> GetAllByState(int stateId)
    {
        return Entity
            .AsNoTracking()
            .Where(c => c.StateId == stateId)
            .Include(c => c.State)
            .Include(c => c.Country)
            .AsSplitQuery()
            .ToList();
    }

    public async Task<IEnumerable<City>> GetAllByStateAsync(int stateId)
    {
        return await Entity
            .AsNoTracking()
            .Where(c => c.StateId == stateId)
            .Include(c => c.State)
            .Include(c => c.Country)
            .AsSplitQuery()
            .ToListAsync();
    }
}