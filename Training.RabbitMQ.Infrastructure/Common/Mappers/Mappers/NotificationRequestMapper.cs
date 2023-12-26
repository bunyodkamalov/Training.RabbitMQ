using AutoMapper;
using Training.RabbitMQ.Application.Common.Notifications.Events;
using Training.RabbitMQ.Application.Common.Notifications.Models;

namespace Training.RabbitMQ.Infrastructure.Common.Mappers.Mappers;

public class NotificationRequestMapper : Profile
{
    public NotificationRequestMapper()
    {
        CreateMap<ProcessNotificationEvent, EmailProcessNotificationEvent>();
    }
}