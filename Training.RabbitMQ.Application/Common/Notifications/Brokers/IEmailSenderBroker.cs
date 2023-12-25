using Training.RabbitMQ.Application.Common.Notifications.Models;

namespace Training.RabbitMQ.Application.Common.Notifications.Brokers;

public interface IEmailSenderBroker
{
    ValueTask<bool> SendAsync(EmailMessage emailMessage, CancellationToken cancellationToken = default);
}