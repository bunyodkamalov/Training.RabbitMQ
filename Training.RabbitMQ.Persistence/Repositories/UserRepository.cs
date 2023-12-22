using System.Linq.Expressions;
using Training.RabbitMQ.Domain.Common.Query;
using Training.RabbitMQ.Domain.Entities.User;
using Training.RabbitMQ.Persistence.Caching.Brokers;
using Training.RabbitMQ.Persistence.DataContexts;
using Training.RabbitMQ.Persistence.Repositories.Interfaces;

namespace Training.RabbitMQ.Persistence.Repositories;

public class UserRepository(IdentityDbContext dbContext, ICacheBroker cacheBroker)
    : EntityRepositoryBase<User, IdentityDbContext>(dbContext, cacheBroker), IUserRepository
{
    public new IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }

    public new ValueTask<IList<User>> GetAsync(QuerySpecification<User> querySpecification, CancellationToken cancellationToken = default)
    {
        return base.GetAsync(querySpecification, cancellationToken);
    }

    public new ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(userId, asNoTracking, cancellationToken);
    }

    public new ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(user, saveChanges, cancellationToken);
    }

    public new ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(user, saveChanges, cancellationToken);
    }
}