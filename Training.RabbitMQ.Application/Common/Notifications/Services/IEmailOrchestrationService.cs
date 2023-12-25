using Training.RabbitMQ.Application.Common.Notifications.Models;
using Training.RabbitMQ.Domain.Common.Exceptions;

namespace Training.RabbitMQ.Application.Common.Notifications.Services;

public interface IEmailOrchestrationService
{
    ValueTask<FuncResult<bool>> SendAsync(EmailProcessNotificationEvent @event, CancellationToken cancellationToken = default);
}