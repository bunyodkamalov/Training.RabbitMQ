using Training.RabbitMQ.Domain.Enums;

namespace Training.RabbitMQ.Infrastructure.Common.Settings;

public class NotificationSettings
{
    public NotificationType DefaultNotificationType { get; set; }
}
