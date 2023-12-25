﻿namespace Training.RabbitMQ.Application.Common.EventBus.Brokers;

public interface IEventSubscriber
{
    ValueTask StartAsync(CancellationToken token);

    ValueTask StopAsync(CancellationToken token);
}