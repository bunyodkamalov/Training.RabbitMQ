using FluentValidation;
using Training.RabbitMQ.Domain.Entities.Subs;
using Training.RabbitMQ.Domain.Enums;

namespace Training.RabbitMQ.Infrastructure.Common.Validations;

public class EmailHistoryValidator : AbstractValidator<EmailHistory>
{
    public EmailHistoryValidator()
    {
        RuleSet(
            EntityEvent.OnCreate.ToString(),
            () =>
            {
                RuleFor(history => history.TemplateId).NotEqual(Guid.Empty);

                RuleFor(history => history.SenderUserId).NotEqual(Guid.Empty);

                RuleFor(history => history.ReceiverUserId).NotEqual(Guid.Empty);

                RuleFor(history => history.Content).NotEmpty().MaximumLength(129_536);

                RuleFor(history => history.ErrorMessage).NotNull().NotEmpty().When(history => !history.IsSuccessful);

                RuleFor(history => history.SenderEmailAddress).NotEmpty().MaximumLength(64);

                RuleFor(history => history.ReceiverEmailAddress).NotEmpty().MaximumLength(64);
            }
        );
    }
}