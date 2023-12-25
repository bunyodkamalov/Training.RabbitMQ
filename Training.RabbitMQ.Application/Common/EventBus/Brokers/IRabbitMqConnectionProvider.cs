using RabbitMQ.Client;

namespace Training.RabbitMQ.Application.Common.EventBus.Brokers;

public interface IRabbitMqConnectionProvider
{
    ValueTask<IChannel> CreateChannelAsync();
}