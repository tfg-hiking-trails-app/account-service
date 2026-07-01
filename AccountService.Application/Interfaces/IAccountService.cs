using AccountService.Application.DTOs;
using AccountService.Application.DTOs.Create;
using AccountService.Application.DTOs.Update;
using Common.Application.Interfaces;

namespace AccountService.Application.Interfaces;

public interface IAccountService : IService<AccountEntityDto, CreateAccountEntityDto, UpdateAccountEntityDto>
{
    Task CreateFromRegistrationAsync(AccountCreationEntityDto accountCreationEntityDto);
    Task UpdateUsernameAsync(UpdateUsernameEntityDto updateUsernameEntityDto);
    Task DeleteProfilePictureAsync(Guid code);
    Task<IEnumerable<AccountEntityDto>> GetByCodesAsync(IEnumerable<Guid> codes);
    Task<IEnumerable<AccountEntityDto>> SearcherAsync(string search, int numberResults);
}