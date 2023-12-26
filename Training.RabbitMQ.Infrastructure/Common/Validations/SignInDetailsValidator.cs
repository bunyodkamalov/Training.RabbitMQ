using FluentValidation;
using Microsoft.Extensions.Options;
using Training.RabbitMQ.Application.Common.Identity.Models;
using Training.RabbitMQ.Infrastructure.Common.Settings;

namespace Training.RabbitMQ.Infrastructure.Common.Validations;

public class SignInDetailsValidator : AbstractValidator<SignInDetails>
{
    public SignInDetailsValidator(IOptions<ValidationSettings> validationSettings)
    {
        var validationSettingsValue = validationSettings.Value;

        RuleFor(x => x.EmailAddress).NotEmpty().Matches(validationSettingsValue.EmailAddressRegexPattern);

        RuleFor(x => x.Password).NotEmpty();
    }
}