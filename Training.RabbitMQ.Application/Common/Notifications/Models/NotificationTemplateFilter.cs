using Training.RabbitMQ.Domain.Common.Query;
using Training.RabbitMQ.Domain.Entities.Bases;
using Training.RabbitMQ.Domain.Enums;

namespace Training.RabbitMQ.Application.Common.Notifications.Models;

public class NotificationTemplateFilter : FilterPagination
{
    public IList<NotificationType> TemplateType { get; set; }
}