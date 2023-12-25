using Training.RabbitMQ.Application.Common.Notifications.Events;
using Training.RabbitMQ.Application.Common.Notifications.Models;
using Training.RabbitMQ.Domain.Common.Exceptions;
using Training.RabbitMQ.Domain.Entities.Bases;

namespace Training.RabbitMQ.Application.Common.Notifications.Services;

public interface INotificationAggregatorService
{
    ValueTask<FuncResult<bool>> SendAsync(ProcessNotificationEvent processNotificationEvent, CancellationToken cancellationToken = default);

    ValueTask<IList<NotificationTemplate>> GetTemplatesByFilterAsync(
        NotificationTemplateFilter filter,
        CancellationToken cancellationToken = default
    );
}