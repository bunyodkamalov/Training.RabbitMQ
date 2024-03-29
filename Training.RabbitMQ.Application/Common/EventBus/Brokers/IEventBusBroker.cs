﻿using Training.RabbitMQ.Domain.Common.Events;

namespace Training.RabbitMQ.Application.Common.EventBus.Brokers;

public interface IEventBusBroker 
{
    ValueTask PublishAsync<TEvent>(TEvent @event, string exchange, string routingKey, CancellationToken cancellationToken) where TEvent : Event;
}