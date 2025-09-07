using AccountService.Application.DTOs;
using AccountService.Application.DTOs.Create;
using AccountService.Application.DTOs.Update;
using AccountService.Application.Interfaces;
using AccountService.Domain.Entities;
using AccountService.Domain.Interfaces;
using AutoMapper;
using Common.Application;
using Common.Application.Interfaces;
using Common.Application.Services;
using Common.Application.Utils;

namespace AccountService.Application.Services;

public class AccountService : AbstractService<Account, AccountEntityDto, CreateAccountEntityDto, UpdateAccountEntityDto>, 
    IAccountService
{
    private readonly IImageService _imageService;
    
    public AccountService(
        IAccountRepository repository, 
        IMapper mapper,
        IImageService imageService) 
        : base(repository, mapper)
    {
        _imageService = imageService;
    }

    public override async Task<Guid> UpdateAsync(Guid code, UpdateAccountEntityDto updateEntityDto)
    {
        Account entity = await GetEntity(code);

        Mapper.Map(updateEntityDto, entity);

        if (updateEntityDto.ProfilePicture is not null)
            entity.ProfilePicture = await UploadProfilePicture(updateEntityDto.ProfilePicture);
        
        await Repository.UpdateAsync(entity);
        
        return entity.Code;
    }
    
    private async Task<string> UploadProfilePicture(FileEntityDto fileEntityDto)
    {
        string extension = Path.GetExtension(fileEntityDto.FileName) 
                           ?? throw new ArgumentException("FileName is not a file");
        
        if (!Validator.ValidExtensionsImage.Contains(extension))
            throw new ArgumentException("Invalid file extension");
        
        if (fileEntityDto.ContentType is null || !Validator.ValidContentTypeImage.Contains(fileEntityDto.ContentType))
            throw new ArgumentException("Invalid file type");
        
        return await _imageService.UploadImage(fileEntityDto);
    }
    
    protected override void CheckDataValidity(CreateAccountEntityDto createEntityDto)
    {
        if (string.IsNullOrEmpty(createEntityDto.Username))
            Validator.CheckNullArgument(createEntityDto.Username, nameof(createEntityDto.Username));
        
        if (createEntityDto.GenderCode.HasValue)
            Validator.CheckGuid(createEntityDto.GenderCode.Value);
    }
    
}