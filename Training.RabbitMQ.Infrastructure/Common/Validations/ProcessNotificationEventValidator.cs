using FluentValidation;
using Training.RabbitMQ.Application.Common.Notifications.Events;

namespace Training.RabbitMQ.Infrastructure.Common.Validations;

public class ProcessNotificationEventValidator : AbstractValidator<ProcessNotificationEvent>
{
    public ProcessNotificationEventValidator()
    {
        RuleFor(history => history.ReceiverUserId).NotEqual(Guid.Empty);
    }
}