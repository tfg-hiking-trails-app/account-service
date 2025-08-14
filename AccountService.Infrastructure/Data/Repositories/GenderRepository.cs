using AccountService.Domain.Entities;
using AccountService.Domain.Interfaces;
using Common.Infrastructure.Data.Repositories;

namespace AccountService.Infrastructure.Data.Repositories;

public class GenderRepository : AbstractRepository<Gender>, IGenderRepository
{
    public GenderRepository(AccountServiceDbContext dbContext) : base(dbContext)
    {
    }
}