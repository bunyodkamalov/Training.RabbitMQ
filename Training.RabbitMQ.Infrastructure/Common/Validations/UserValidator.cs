﻿using FluentValidation;
using Microsoft.Extensions.Options;
using Training.RabbitMQ.Domain.Entities.User;
using Training.RabbitMQ.Infrastructure.Common.Settings;

namespace Training.RabbitMQ.Infrastructure.Common.Validations;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator(IOptions<ValidationSettings> validationSettings)
    {
        var validationSettingsValue = validationSettings.Value;

        RuleFor(signUpDetails => signUpDetails.EmailAddress)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(64)
            .Matches(validationSettingsValue.EmailAddressRegexPattern);

        RuleFor(signUpDetails => signUpDetails.FirstName)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(64)
            .Matches(validationSettingsValue.NameRegexPattern)
            .WithMessage("First name is not valid");

        RuleFor(signUpDetails => signUpDetails.LastName)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(64)
            .Matches(validationSettingsValue.NameRegexPattern)
            .WithMessage("Last name is not valid");

        RuleFor(signUpDetails => signUpDetails.Age).GreaterThanOrEqualTo(18).LessThanOrEqualTo(130);
    }
}