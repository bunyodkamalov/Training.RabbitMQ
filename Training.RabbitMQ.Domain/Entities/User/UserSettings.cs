using Training.RabbitMQ.Domain.Common.Entities;
using Training.RabbitMQ.Domain.Enums;

namespace Training.RabbitMQ.Domain.Entities.User;

public class UserSettings : IEntity
{
    public NotificationType? PreferredNotificationType { get; set; }
    
    public Guid Id { get; set; }
}