using AccountService.Application.DTOs;
using AccountService.Application.DTOs.Create;
using AccountService.Application.DTOs.Update;
using AccountService.Application.Interfaces;
using AccountService.Domain.Entities;
using AccountService.Domain.Interfaces;
using AutoMapper;
using Common.Application.Interfaces;
using Common.Application.Services;
using Common.Application.Utils;
using Common.Domain.Exceptions;

namespace AccountService.Application.Services;

public class AccountService : AbstractService<Account, AccountEntityDto, CreateAccountEntityDto, UpdateAccountEntityDto>, 
    IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IGenderRepository _genderRepository;
    private readonly IUploadImageService _uploadImageService;
    
    public AccountService(
        IAccountRepository repository,
        IGenderRepository genderRepository,
        IMapper mapper,
        IUploadImageService uploadImageService) 
        : base(repository, mapper)
    {
        _accountRepository = repository;
        _genderRepository = genderRepository;
        _uploadImageService = uploadImageService;
    }

    public override async Task<Guid> UpdateAsync(Guid code, UpdateAccountEntityDto updateEntityDto)
    {
        Account account = await GetEntityAsync(code);
        
        if (account is null)
            throw new NotFoundEntityException(nameof(Account), "code", code.ToString());

        Mapper.Map(updateEntityDto, account);

        if (updateEntityDto.UploadImage?.Content.Length > 0)
            account.ProfilePicture = await _uploadImageService.UploadImage(updateEntityDto.UploadImage);
        else if (updateEntityDto.RemovedImage)
        {
            if (account.ProfilePicture is not null)
                await _uploadImageService.RemoveImage(_uploadImageService.GetPublicIdFromUrl(account.ProfilePicture));
            
            account.ProfilePicture = null;
        }
        
        UpdateGender(account, updateEntityDto.GenderCode);
        
        await Repository.SaveChangesAsync();
        
        return account.Code;
    }

    public async Task UpdateUsernameAsync(UpdateUsernameEntityDto updateUsernameEntityDto)
    {
        Account? account = await _accountRepository.GetByUsernameAsync(updateUsernameEntityDto.OldUsername);

        if (account is null)
            throw new NotFoundEntityException(nameof(Account), "username", updateUsernameEntityDto.OldUsername);
        
        account.Username = updateUsernameEntityDto.NewUsername;

        await _accountRepository.SaveChangesAsync();
    }

    public async Task<IEnumerable<AccountEntityDto>> SearcherAsync(string search, int numberResults)
    {
        IEnumerable<Account> accounts = await _accountRepository.SearcherAsync(search, numberResults);
        
        return Mapper.Map<IEnumerable<AccountEntityDto>>(accounts);
    }

    protected override void CheckDataValidity(CreateAccountEntityDto createEntityDto)
    {
        if (string.IsNullOrEmpty(createEntityDto.Username))
            Validator.CheckNullArgument(createEntityDto.Username, nameof(createEntityDto.Username));
    }

    private void UpdateGender(Account account, Guid? genderCode)
    {
        // Delete gender
        if (!genderCode.HasValue)
        {
            account.Gender = null;
            return;
        }
        
        // Assign gender
        if (genderCode != Guid.Empty && account.Gender?.Code != genderCode)
        {
            Gender? gender = _genderRepository.GetByCode(genderCode.Value);
            
            if (gender is not null)
                account.Gender = gender;
        }
    }
}