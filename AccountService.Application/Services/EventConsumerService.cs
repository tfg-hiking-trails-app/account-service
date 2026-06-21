using AccountService.Application.DTOs.Update;
using AccountService.Application.Interfaces;
using AccountService.Domain.Interfaces.Messaging;

namespace AccountService.Application.Services;

public class EventConsumerService : IEventConsumerService
{
    private readonly IUsernameChangeQueueConsumer _queueConsumer;
    private readonly IAccountService _accountService;

    public EventConsumerService(
        IUsernameChangeQueueConsumer queueConsumer,
        IAccountService accountService)
    {
        _queueConsumer = queueConsumer;
        _accountService = accountService;
    }
    
    public async Task Consume()
    {
        UpdateUsernameEntityDto updateUsernameEntityDto = await _queueConsumer.BasicConsumeAsync<UpdateUsernameEntityDto>();

        await _accountService.UpdateUsernameAsync(updateUsernameEntityDto);
    }
}