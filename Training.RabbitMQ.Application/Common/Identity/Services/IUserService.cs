﻿using System.Linq.Expressions;
using Training.RabbitMQ.Domain.Common.Query;
using Training.RabbitMQ.Domain.Entities.User;

namespace Training.RabbitMQ.Application.Common.Identity.Services;

public interface IUserService
{
    IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<IList<User>> GetAsync(QuerySpecification<User> querySpecification, CancellationToken cancellationToken = default);

    ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<User> GetSystemUserAsync(bool asNoTracking = false, CancellationToken cancellationToken = default);

    Task<Guid?> GetIdByEmailAddressAsync(string emailAddress, CancellationToken cancellationToken = default);

    ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);
}