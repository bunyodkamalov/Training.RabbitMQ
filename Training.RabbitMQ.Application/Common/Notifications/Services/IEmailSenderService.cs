using Training.RabbitMQ.Application.Common.Notifications.Models;

namespace Training.RabbitMQ.Application.Common.Notifications.Services;

public interface IEmailSenderService
{
    ValueTask<bool> SendAsync(EmailMessage emailMessage, CancellationToken cancellationToken = default);
}