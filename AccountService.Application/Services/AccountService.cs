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
    private readonly ICountryRepository _countryRepository;
    private readonly IStateRepository _stateRepository;
    private readonly ICityRepository _cityRepository;
    private readonly IImageService _imageService;
    
    public AccountService(
        IAccountRepository repository,
        IGenderRepository genderRepository,
        ICountryRepository countryRepository,
        IStateRepository stateRepository,
        ICityRepository cityRepository,
        IMapper mapper,
        IImageService imageService) 
        : base(repository, mapper)
    {
        _accountRepository = repository;
        _genderRepository = genderRepository;
        _countryRepository = countryRepository;
        _stateRepository = stateRepository;
        _cityRepository = cityRepository;
        _imageService = imageService;
    }

    public override async Task<Guid> UpdateAsync(Guid code, UpdateAccountEntityDto updateEntityDto)
    {
        Account entity = await GetEntity(code);

        Mapper.Map(updateEntityDto, entity);

        if (updateEntityDto.UploadImage?.Content.Length > 0)
            entity.ProfilePicture = await _imageService.UploadImage(updateEntityDto.UploadImage);
        else if (updateEntityDto.RemovedImage)
        {
            if (entity.ProfilePicture is not null)
                await _imageService.RemoveImage(_imageService.GetPublicIdFromUrl(entity.ProfilePicture));
            
            entity.ProfilePicture = null;
        }

        // Update gender
        if (updateEntityDto.GenderCode is Guid genderCode && entity.Gender?.Code != genderCode)
        {
            Gender? gender = await _genderRepository.GetByCodeAsync(genderCode);
            
            if (gender is not null)
                entity.Gender = gender;
        }
        
        // Update country
        if (updateEntityDto.CountryCode is Guid countryCode && entity.Country?.Code != countryCode)
        {
            Country? country = await _countryRepository.GetByCodeAsync(countryCode);
            
            if (country is not null)
                entity.Country = country;
        }
        
        // Update state
        if (updateEntityDto.StateCode is Guid stateCode && entity.State?.Code != stateCode)
        {
            State? state = await _stateRepository.GetByCodeAsync(stateCode);
            
            if (state is not null)
                entity.State = state;
        }
        
        // Update city
        if (updateEntityDto.CityCode is Guid cityCode && entity.City?.Code != cityCode)
        {
            City? city = await _cityRepository.GetByCodeAsync(cityCode);
            
            if (city is not null)
                entity.City = city;
        }
        
        await Repository.UpdateAsync(entity);
        
        return entity.Code;
    }

    public async Task UpdateUsernameAsync(UpdateUsernameEntityDto updateUsernameEntityDto)
    {
        Account? account = await _accountRepository.GetByUsernameAsync(updateUsernameEntityDto.OldUsername);

        if (account is null)
            throw new NotFoundEntityException(nameof(Account), "username", updateUsernameEntityDto.OldUsername);
        
        account.Username = updateUsernameEntityDto.NewUsername;

        await _accountRepository.SaveChangesAsync();
    }

    protected override void CheckDataValidity(CreateAccountEntityDto createEntityDto)
    {
        if (string.IsNullOrEmpty(createEntityDto.Username))
            Validator.CheckNullArgument(createEntityDto.Username, nameof(createEntityDto.Username));
        
        if (createEntityDto.GenderCode.HasValue)
            Validator.CheckGuid(createEntityDto.GenderCode.Value);
    }
    
}