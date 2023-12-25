namespace Training.RabbitMQ.Application.Common.EventBus.Brokers;

public interface IEventBusBroker
{
    ValueTask PublishAsync<TEvent>(TEvent @event, string exchange, string routingKey, CancellationToken cancellationToken);
}