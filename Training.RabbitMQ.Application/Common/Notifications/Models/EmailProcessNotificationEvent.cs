using Training.RabbitMQ.Application.Common.Notifications.Events;
using Training.RabbitMQ.Domain.Enums;

namespace Training.RabbitMQ.Application.Common.Notifications.Models;

public class EmailProcessNotificationEvent : ProcessNotificationEvent
{
    public EmailProcessNotificationEvent()
    {
        Type = NotificationType.Email;
    }
}