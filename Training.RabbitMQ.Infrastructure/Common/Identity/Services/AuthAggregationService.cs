﻿using AutoMapper;
using Training.RabbitMQ.Application.Common.Identity.Models;
using Training.RabbitMQ.Application.Common.Identity.Services;
using Training.RabbitMQ.Domain.Entities.User;

namespace Training.RabbitMQ.Infrastructure.Common.Identity.Services;

public class AuthAggregationService(
    IMapper mapper,
    IPasswordGeneratorService passwordGeneratorService,
    IPasswordHasherService passwordHasherService,
    IAccountAggregatorService accountAggregatorService,
    IUserService userService
) : IAuthAggregationService
{
    public async ValueTask<bool> SignUpAsync(SignUpDetails signUpDetails, CancellationToken cancellationToken = default)
    {
        var foundUserId = await userService.GetIdByEmailAddressAsync(signUpDetails.EmailAddress, cancellationToken);

        if (foundUserId.HasValue)
            throw new InvalidOperationException("User already exists");

        // Hash password
        var user = mapper.Map<User>(signUpDetails);
        var password = signUpDetails.AutoGeneratePassword
            ? passwordGeneratorService.GeneratePassword()
            : passwordGeneratorService.GetValidatedPassword(signUpDetails.Password!, user);

        user.PasswordHash = passwordHasherService.HashPassword(password);

        // Create user
        return await accountAggregatorService.CreateUserAsync(user, cancellationToken);
    }
}