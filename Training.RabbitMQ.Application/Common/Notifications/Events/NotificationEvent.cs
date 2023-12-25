using Training.RabbitMQ.Domain.Common.Events;

namespace Training.RabbitMQ.Application.Common.Notifications.Events;

public class NotificationEvent : Event
{
    public Guid SenderUserId { get; init; }
    
    public Guid ReceiverUserId { get; init; }
}