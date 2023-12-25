using Training.RabbitMQ.Domain.Enums;

namespace Training.RabbitMQ.Application.Common.Notifications.Events;

public class ProcessNotificationEvent : NotificationEvent
{
    public NotificationTemplateType TemplateType { get; init; }
    
    public NotificationType? Type { get; set; }
    
    public Dictionary<string, string>? Variables { get; set; }
}