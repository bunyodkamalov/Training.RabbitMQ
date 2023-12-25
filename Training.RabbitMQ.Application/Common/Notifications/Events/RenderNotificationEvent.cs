﻿using Training.RabbitMQ.Domain.Entities.Bases;
using Training.RabbitMQ.Domain.Entities.User;

namespace Training.RabbitMQ.Application.Common.Notifications.Events;

public class RenderNotificationEvent : NotificationEvent
{
    public NotificationTemplate Template { get; set; } = default!;

    public User SenderUser { get; init; } = default!;

    public User ReceiverUser { get; init; } = default!;

    public Dictionary<string, string> Variables { get; set; } = new();
}