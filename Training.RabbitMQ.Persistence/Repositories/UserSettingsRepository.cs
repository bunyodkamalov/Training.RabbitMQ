using Training.RabbitMQ.Domain.Entities.User;
using Training.RabbitMQ.Persistence.Caching.Brokers;
using Training.RabbitMQ.Persistence.DataContexts;
using Training.RabbitMQ.Persistence.Repositories.Interfaces;

namespace Training.RabbitMQ.Persistence.Repositories;

public class UserSettingsRepository(IdentityDbContext dbContext, ICacheBroker cacheBroker)
    : EntityRepositoryBase<UserSettings, IdentityDbContext>(dbContext, cacheBroker), IUserSettingsRepository
{
    public new ValueTask<UserSettings?> GetByIdAsync(Guid userId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(userId, asNoTracking, cancellationToken);
    }

    public new ValueTask<UserSettings> CreateAsync(UserSettings userSettings, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(userSettings, saveChanges, cancellationToken);
    }
}