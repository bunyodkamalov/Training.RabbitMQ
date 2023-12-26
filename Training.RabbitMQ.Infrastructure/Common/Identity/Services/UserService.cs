﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Training.RabbitMQ.Application.Common.Identity.Services;
using Training.RabbitMQ.Domain.Common.Query;
using Training.RabbitMQ.Domain.Entities.User;
using Training.RabbitMQ.Domain.Enums;
using Training.RabbitMQ.Persistence.Repositories.Interfaces;

namespace Training.RabbitMQ.Infrastructure.Common.Identity.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false)
    {
        return userRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<IList<User>> GetAsync(QuerySpecification<User> querySpecification, CancellationToken cancellationToken = default)
    {
        return userRepository.GetAsync(querySpecification, cancellationToken);
    }

    public ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return userRepository.GetByIdAsync(userId, asNoTracking, cancellationToken);
    }

    public async ValueTask<User> GetSystemUserAsync(bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return await Get(user => user.Role == RoleType.System, asNoTracking).FirstAsync(cancellationToken);
    }

    public async Task<Guid?> GetIdByEmailAddressAsync(string emailAddress, CancellationToken cancellationToken = default)
    {
        var userId = await Get(user => user.EmailAddress == emailAddress, true).Select(user => user.Id).FirstOrDefaultAsync(cancellationToken);
        return userId != Guid.Empty ? userId : default(Guid?);
    }

    public ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return userRepository.CreateAsync(user, saveChanges, cancellationToken);
    }

    public ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return userRepository.UpdateAsync(user, saveChanges, cancellationToken);
    }
}