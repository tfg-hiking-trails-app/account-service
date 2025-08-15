using AccountService.Application.DTOs;
using AccountService.Application.DTOs.Create;
using AccountService.Application.DTOs.Update;
using Common.Application.DTOs.Filter;
using Common.Application.Interfaces;
using Common.Application.Pagination;

namespace AccountService.Application.Interfaces;

public interface IAccountFollowService : IService<AccountFollowEntityDto, CreateAccountFollowEntityDto, UpdateAccountFollowEntityDto>
{
    Task<Page<AccountEntityDto>> GetFollowersByAccountCode(Guid accountCode, 
        FilterEntityDto filter, CancellationToken cancellationToken);
    Task<Page<AccountEntityDto>> GetFollowedByAccountCode(Guid accountCode, 
        FilterEntityDto filter, CancellationToken cancellationToken);
}