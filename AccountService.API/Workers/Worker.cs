using AccountService.Application.Interfaces;

namespace AccountService.API.Workers;

public class Worker : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public Worker(IServiceScopeFactory scopeFactory)
    {
        _serviceScopeFactory = scopeFactory;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (IServiceScope scope = _serviceScopeFactory.CreateScope())
            {
                IEventConsumerService consumer = scope.ServiceProvider
                    .GetRequiredService<IEventConsumerService>();
                    
                await consumer.Consume();
            }
        }
    }
}