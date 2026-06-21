using AccountService.Application.Interfaces;

namespace AccountService.API.Workers;

public class AccountCreationWorker : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public AccountCreationWorker(IServiceScopeFactory scopeFactory)
    {
        _serviceScopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (IServiceScope scope = _serviceScopeFactory.CreateScope())
            {
                IAccountCreationConsumerService consumer = scope.ServiceProvider
                    .GetRequiredService<IAccountCreationConsumerService>();

                await consumer.Consume();
            }
        }
    }
}
