using AutoMapper;
using Training.RabbitMQ.Application.Common.Notifications.Models;

namespace Training.RabbitMQ.Infrastructure.Common.Mappers.Mappers;

public class NotificationMessageMapper : Profile
{
    public NotificationMessageMapper()
    {
        CreateMap<EmailProcessNotificationEvent, EmailMessage>();
    }
}