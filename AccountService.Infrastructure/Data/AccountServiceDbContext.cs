using Common.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AccountService.Infrastructure.Data;

public class AccountServiceDbContext : AbstractDbContext
{
    public AccountServiceDbContext(DbContextOptions<AccountServiceDbContext> options) : base(options)
    {
    }
}