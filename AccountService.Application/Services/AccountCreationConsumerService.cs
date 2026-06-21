using AccountService.Application.DTOs.Create;
using AccountService.Application.Interfaces;
using AccountService.Domain.Interfaces.Messaging;

namespace AccountService.Application.Services;

public class AccountCreationConsumerService : IAccountCreationConsumerService
{
    private readonly IAccountCreationQueueConsumer _queueConsumer;
    private readonly IAccountService _accountService;

    public AccountCreationConsumerService(
        IAccountCreationQueueConsumer queueConsumer,
        IAccountService accountService)
    {
        _queueConsumer = queueConsumer;
        _accountService = accountService;
    }

    public async Task Consume()
    {
        AccountCreationEntityDto accountCreationEntityDto =
            await _queueConsumer.BasicConsumeAsync<AccountCreationEntityDto>();

        await _accountService.CreateFromRegistrationAsync(accountCreationEntityDto);
    }
}
