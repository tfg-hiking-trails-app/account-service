using AccountService.Domain.Entities;
using Common.Domain.Interfaces;

namespace AccountService.Domain.Interfaces;

public interface IAccountRepository : IRepository<Account>
{
    Account? GetByUsername(string username);
    Task<Account?> GetByUsernameAsync(string username);
}