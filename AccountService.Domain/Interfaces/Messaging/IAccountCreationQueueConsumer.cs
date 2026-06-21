using Common.Domain.Interfaces.Messaging;

namespace AccountService.Domain.Interfaces.Messaging;

public interface IAccountCreationQueueConsumer : IRabbitMqQueueConsumer
{
}
