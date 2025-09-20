using AccountService.Domain.Entities;
using AccountService.Domain.Interfaces;
using Common.Application.Extensions;
using Common.Domain.Filter;
using Common.Domain.Interfaces;
using Common.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Infrastructure.Data.Repositories;

public class SubregionRepository : AbstractRepository<Subregion>, ISubregionRepository
{
    public SubregionRepository(AccountServiceDbContext dbContext) : base(dbContext)
    {
    }
    
    public override IEnumerable<Subregion> GetAll()
    {
        return Entity
            .Include(a => a.Region)
            .Include(a => a.Countries)
            .ToList();
    }

    public override async Task<IEnumerable<Subregion>> GetAllAsync()
    {
        return await Entity
            .Include(a => a.Region)
            .Include(a => a.Countries)
            .ToListAsync();    }
    
    public override async Task<IPaged<Subregion>> GetPagedAsync(
        FilterData filter, 
        CancellationToken cancellationToken)
    {
        return await Entity
            .Include(a => a.Region)
            .Include(a => a.Countries)
            .ToPageAsync(filter, cancellationToken);
    }

    public override Subregion? Get(int id)
    {
        return Entity
            .Include(a => a.Region)
            .Include(a => a.Countries)
            .FirstOrDefault(a => a.Id == id);
    }

    public override async Task<Subregion?> GetAsync(int id)
    {
        return await Entity
            .Include(a => a.Region)
            .Include(a => a.Countries)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public override Subregion? GetByCode(Guid code)
    {
        return Entity
            .Include(a => a.Region)
            .Include(a => a.Countries)
            .FirstOrDefault(a => a.Code == code);
    }

    public override async Task<Subregion?> GetByCodeAsync(Guid code)
    {
        return await Entity
            .Include(a => a.Region)
            .Include(a => a.Countries)
            .FirstOrDefaultAsync(a => a.Code == code);
    }
    
}