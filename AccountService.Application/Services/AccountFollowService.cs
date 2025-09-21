using AccountService.Application.DTOs;
using AccountService.Application.DTOs.Create;
using AccountService.Application.DTOs.Update;
using AccountService.Application.Interfaces;
using AccountService.Domain.Entities;
using AccountService.Domain.Interfaces;
using AutoMapper;
using Common.Application.DTOs.Filter;
using Common.Application.Pagination;
using Common.Application.Services;
using Common.Application.Utils;
using Common.Domain.Filter;
using Common.Domain.Interfaces;

namespace AccountService.Application.Services;

public class AccountFollowService : AbstractService<AccountFollow, AccountFollowEntityDto, CreateAccountFollowEntityDto, UpdateAccountFollowEntityDto>, 
    IAccountFollowService
{
    private readonly IMapper _mapper;
    private readonly IAccountService _accountService;
    private readonly IAccountFollowRepository _accountFollowRepository;
    
    public AccountFollowService(
        IAccountService accountService,
        IAccountFollowRepository accountFollowRepository,
        IMapper mapper) : 
        base(accountFollowRepository, mapper)
    {
        _mapper = mapper;
        _accountService = accountService;
        _accountFollowRepository = accountFollowRepository;
    }

    public async Task<Page<AccountEntityDto>> GetFollowersByAccountCode(Guid accountCode, 
        FilterEntityDto filter, CancellationToken cancellationToken)
    {
        AccountEntityDto account = await _accountService.GetByCodeAsync(accountCode);
        
        IPaged<AccountFollow> followers = await _accountFollowRepository.GetFollowersByAccount(account.Id, 
            _mapper.Map<FilterData>(filter), cancellationToken);
        
        Page<AccountEntityDto> result = new Page<AccountEntityDto>(
            followers.Content.Select(x => _mapper.Map<AccountEntityDto>(x.FollowerAccount)).ToList(), 
            followers.PageNumber,
            followers.PageSize, 
            followers.TotalCount);
        
        return _mapper.Map<Page<AccountEntityDto>>(result);
    }

    public async Task<IEnumerable<AccountEntityDto>> GetAllFollowersByAccountCode(Guid accountCode)
    {
        AccountEntityDto account = await _accountService.GetByCodeAsync(accountCode);
        
        IEnumerable<AccountFollow> followers = await _accountFollowRepository.GetAllFollowersByAccount(account.Id);
        
        return followers
            .Select(x => _mapper.Map<AccountEntityDto>(x.FollowerAccount))
            .ToList();
    }

    public async Task<Page<AccountEntityDto>> GetFollowedByAccountCode(Guid accountCode, 
        FilterEntityDto filter, CancellationToken cancellationToken)
    {
        AccountEntityDto account = await _accountService.GetByCodeAsync(accountCode);
        
        IPaged<AccountFollow> followed = await _accountFollowRepository.GetFollowedByAccount(account.Id, 
            _mapper.Map<FilterData>(filter), cancellationToken);
        
        Page<AccountEntityDto> result = new Page<AccountEntityDto>(
            followed.Content.Select(x => _mapper.Map<AccountEntityDto>(x.FollowedAccount)).ToList(), 
            followed.PageNumber,
            followed.PageSize, 
            followed.TotalCount);
        
        return _mapper.Map<Page<AccountEntityDto>>(result);
    }

    public async Task<IEnumerable<AccountEntityDto>> GetAllFollowedByAccountCode(Guid accountCode)
    {
        AccountEntityDto account = await _accountService.GetByCodeAsync(accountCode);
        
        IEnumerable<AccountFollow> followed = await _accountFollowRepository.GetAllFollowedByAccount(account.Id);
        
        return followed
            .Select(x => _mapper.Map<AccountEntityDto>(x.FollowedAccount))
            .ToList();
    }

    public async Task<int> GetFollowersCountByAccountCode(Guid accountCode)
    {
        AccountEntityDto account = await _accountService.GetByCodeAsync(accountCode);
        
        return await _accountFollowRepository.GetFollowersCountByAccount(account.Id);
    }

    public async Task<int> GetFollowedCountByAccountCode(Guid accountCode)
    {
        AccountEntityDto account = await _accountService.GetByCodeAsync(accountCode);
        
        return await _accountFollowRepository.GetFollowedCountByAccount(account.Id);
    }

    protected override void CheckDataValidity(CreateAccountFollowEntityDto createEntityDto)
    {
        if (createEntityDto.FollowerAccountCode.HasValue)
            Validator.CheckGuid(createEntityDto.FollowerAccountCode.Value);
        
        if (createEntityDto.FollowedAccountCode.HasValue)
            Validator.CheckGuid(createEntityDto.FollowedAccountCode.Value);
    }
    
}