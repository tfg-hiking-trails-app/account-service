namespace AccountService.Application.Interfaces;

public interface IEventConsumerService
{
    Task Consume();
}