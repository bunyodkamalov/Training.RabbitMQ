using AutoMapper;
using Training.RabbitMQ.Application.Common.Notifications.Models;
using Training.RabbitMQ.Domain.Entities.Subs;

namespace Training.RabbitMQ.Infrastructure.Common.Mappers.Mappers;

public class NotificationHistoryMapper : Profile
{
    public NotificationHistoryMapper()
    {
        CreateMap<EmailMessage, EmailHistory>()
            .ForMember(dest => dest.TemplateId, opt => opt.MapFrom(src => src.Template.Id))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Body));
    }
}