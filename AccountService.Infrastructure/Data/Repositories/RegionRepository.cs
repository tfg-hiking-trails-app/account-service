using AccountService.Domain.Entities;
using AccountService.Domain.Interfaces;
using Common.Application.Extensions;
using Common.Domain.Filter;
using Common.Domain.Interfaces;
using Common.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Infrastructure.Data.Repositories;

public class RegionRepository : AbstractRepository<Region>, IRegionRepository
{
    public RegionRepository(AccountServiceDbContext dbContext) : base(dbContext)
    {
    }
    
    public override IEnumerable<Region> GetAll()
    {
        return Entity
            .Include(r => r.Countries)
            .Include(r => r.Subregions)
            .ToList();
    }

    public override async Task<IEnumerable<Region>> GetAllAsync()
    {
        return await Entity
            .Include(r => r.Countries)
            .Include(r => r.Subregions)
            .ToListAsync();    }
    
    public override async Task<IPaged<Region>> GetPagedAsync(
        FilterData filter, 
        CancellationToken cancellationToken)
    {
        return await Entity
            .Include(r => r.Countries)
            .Include(r => r.Subregions)
            .ToPageAsync(filter, cancellationToken);
    }

    public override Region? Get(int id)
    {
        return Entity
            .Include(r => r.Countries)
            .Include(r => r.Subregions)
            .FirstOrDefault(r => r.Id == id);
    }

    public override async Task<Region?> GetAsync(int id)
    {
        return await Entity
            .Include(r => r.Countries)
            .Include(r => r.Subregions)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public override Region? GetByCode(Guid code)
    {
        return Entity
            .Include(r => r.Countries)
            .Include(r => r.Subregions)
            .FirstOrDefault(r => r.Code == code);
    }

    public override async Task<Region?> GetByCodeAsync(Guid code)
    {
        return await Entity
            .Include(r => r.Countries)
            .Include(r => r.Subregions)
            .FirstOrDefaultAsync(r => r.Code == code);
    }
    
}