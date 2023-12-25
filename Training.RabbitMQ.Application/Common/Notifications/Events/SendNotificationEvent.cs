using Training.RabbitMQ.Application.Common.Notifications.Models;

namespace Training.RabbitMQ.Application.Common.Notifications.Events;

public class SendNotificationEvent : NotificationEvent
{
    public NotificationMessage Message { get; set; } = default!;
}