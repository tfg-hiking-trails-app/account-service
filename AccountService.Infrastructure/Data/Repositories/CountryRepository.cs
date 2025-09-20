using AccountService.Domain.Entities;
using AccountService.Domain.Interfaces;
using Common.Application.Extensions;
using Common.Domain.Filter;
using Common.Domain.Interfaces;
using Common.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Infrastructure.Data.Repositories;

public class CountryRepository : AbstractRepository<Country>, ICountryRepository
{
    public CountryRepository(AccountServiceDbContext dbContext) : base(dbContext)
    {
    }
    
    public override IEnumerable<Country> GetAll()
    {
        return Entity
            .Include(a => a.RegionEntity)
            .Include(a => a.SubregionEntity)
            .Include(a => a.States)
            .ToList();
    }

    public override async Task<IEnumerable<Country>> GetAllAsync()
    {
        return await Entity
            .Include(a => a.RegionEntity)
            .Include(a => a.SubregionEntity)
            .Include(a => a.States)
            .ToListAsync();    }
    
    public override async Task<IPaged<Country>> GetPagedAsync(
        FilterData filter, 
        CancellationToken cancellationToken)
    {
        return await Entity
            .Include(a => a.RegionEntity)
            .Include(a => a.SubregionEntity)
            .Include(a => a.States)
            .ToPageAsync(filter, cancellationToken);
    }

    public override Country? Get(int id)
    {
        return Entity
            .Include(a => a.RegionEntity)
            .Include(a => a.SubregionEntity)
            .Include(a => a.States)
            .FirstOrDefault(a => a.Id == id);
    }

    public override async Task<Country?> GetAsync(int id)
    {
        return await Entity
            .Include(a => a.RegionEntity)
            .Include(a => a.SubregionEntity)
            .Include(a => a.States)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public override Country? GetByCode(Guid code)
    {
        return Entity
            .Include(a => a.RegionEntity)
            .Include(a => a.SubregionEntity)
            .Include(a => a.States)
            .FirstOrDefault(a => a.Code == code);
    }

    public override async Task<Country?> GetByCodeAsync(Guid code)
    {
        return await Entity
            .AsNoTracking()
            .Include(a => a.RegionEntity)
            .Include(a => a.SubregionEntity)
            .Include(a => a.States)
            .AsSplitQuery()
            .FirstOrDefaultAsync(a => a.Code == code);
    }
    
}