﻿using Training.RabbitMQ.Application.Common.EventBus.Brokers;
using Training.RabbitMQ.Application.Common.Identity.Services;
using Training.RabbitMQ.Application.Common.Notifications.Events;
using Training.RabbitMQ.Application.Common.Notifications.Models;
using Training.RabbitMQ.Application.Common.Verifications.Services;
using Training.RabbitMQ.Domain.Constants;
using Training.RabbitMQ.Domain.Entities.User;
using Training.RabbitMQ.Domain.Enums;

namespace Training.RabbitMQ.Infrastructure.Common.Identity.Services;

public class AccountAggregatorService(
    IUserService userService,
    IUserSettingsService userSettingsService,
    IUserInfoVerificationCodeService userInfoVerificationCodeService,
    IEventBusBroker eventBusBroker
) : IAccountAggregatorService
{
    public async ValueTask<bool> CreateUserAsync(User user, CancellationToken cancellationToken = default)
    {
        // Create user and user settings
        user.Role = RoleType.User;
        var createdUser = await userService.CreateAsync(user, cancellationToken: cancellationToken);
        await userSettingsService.CreateAsync(
            new UserSettings
            {
                Id = createdUser.Id
            },
            cancellationToken: cancellationToken
        );

        // send welcome email
        // var systemUser = await userService.GetSystemUserAsync(cancellationToken: cancellationToken);

        var welcomeNotificationEvent = new ProcessNotificationEvent
        {
            ReceiverUserId = createdUser.Id,
            TemplateType = NotificationTemplateType.WelcomeNotification,
            Variables = new Dictionary<string, string>
            {
                { NotificationTemplateConstants.UserNamePlaceholder, createdUser.FirstName }
            }
        };

        // send verification email
        await eventBusBroker.PublishAsync(
            welcomeNotificationEvent,
            EventBusConstants.NotificationExchangeName,
            EventBusConstants.ProcessNotificationQueueName,
            cancellationToken
        );

        var verificationCode = await userInfoVerificationCodeService.CreateAsync(
            VerificationCodeType.EmailAddressVerification,
            createdUser.Id,
            cancellationToken
        );

        // send verification email
        var sendVerificationEvent = new EmailProcessNotificationEvent
        {
            ReceiverUserId = createdUser.Id,
            TemplateType = NotificationTemplateType.EmailAddressVerificationNotification,
            Variables = new Dictionary<string, string>
            {
                { NotificationTemplateConstants.EmailAddressVerificationLinkPlaceholder, verificationCode.VerificationLink }
            }
        };

        await eventBusBroker.PublishAsync(
            sendVerificationEvent,
            EventBusConstants.NotificationExchangeName,
            EventBusConstants.ProcessNotificationQueueName,
            cancellationToken
        );

        // await emailOrchestrationService.SendAsync(
        //     new EmailProcessNotificationEvent
        //     {
        //         SenderUserId = systemUser.Id,
        //         ReceiverUserId = createdUser.Id,
        //         TemplateType = NotificationTemplateType.EmailAddressVerificationNotification,
        //         Variables = new Dictionary<string, string>
        //         {
        //             { NotificationTemplateConstants.EmailAddressVerificationLinkPlaceholder, verificationCode.VerificationLink }
        //         }
        //     },
        //     cancellationToken
        // );

        return true;
    }
}