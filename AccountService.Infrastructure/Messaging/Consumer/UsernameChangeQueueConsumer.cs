using AccountService.Domain.Interfaces.Messaging;
using Common.Domain.Interfaces.Messaging;
using Common.Infrastructure.Messaging;

namespace AccountService.Infrastructure.Messaging.Consumer;

public class UsernameChangeQueueConsumer : AbstractRabbitMqQueueConsumer, IUsernameChangeQueueConsumer
{
    public override string QueueName { get; }
    public override string ExchangeName { get; }

    public UsernameChangeQueueConsumer(IRabbitMqQueueProvider channelProvider) : base(channelProvider)
    {
        QueueName = GetUsingEnvironmentVariable("RABBITMQ_QUEUE_AUTH_TO_ACCOUNT");
        ExchangeName = GetUsingEnvironmentVariable("RABBITMQ_EXCHANGE_AUTH_SERVICE");
    }
}
