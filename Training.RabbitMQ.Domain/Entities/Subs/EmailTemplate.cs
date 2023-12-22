using Training.RabbitMQ.Domain.Entities.Bases;
using Training.RabbitMQ.Domain.Enums;

namespace Training.RabbitMQ.Domain.Entities.Subs;

public class EmailTemplate : NotificationTemplate
{
    public EmailTemplate()
    {
        Type = NotificationType.Email;
    }

    public string Subject { get; set; } = default!;
}