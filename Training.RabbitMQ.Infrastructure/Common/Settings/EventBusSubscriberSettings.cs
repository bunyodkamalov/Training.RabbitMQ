namespace Training.RabbitMQ.Infrastructure.Common.Settings;

public abstract class EventBusSubscriberSettings
{
    public ushort PrefetchCount { get; set; }
}