﻿using System.Linq.Expressions;
using Training.RabbitMQ.Domain.Entities.User;

namespace Training.RabbitMQ.Persistence.Repositories.Interfaces;

public interface IUserInfoVerificationCodeRepository
{
    IQueryable<UserInfoVerificationCode> Get(Expression<Func<UserInfoVerificationCode, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<UserInfoVerificationCode?> GetByIdAsync(Guid codeId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<UserInfoVerificationCode> CreateAsync(
        UserInfoVerificationCode verificationCode,
        bool saveChanges = true,
        CancellationToken cancellationToken = default
    );

    ValueTask DeactivateAsync(Guid codeId, bool saveChanges = true, CancellationToken cancellationToken = default);
}