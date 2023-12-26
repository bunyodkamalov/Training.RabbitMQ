using Training.RabbitMQ.Application.Common.Identity.Services;
using Training.RabbitMQ.Domain.Entities.User;
using Training.RabbitMQ.Persistence.Repositories.Interfaces;

namespace Training.RabbitMQ.Infrastructure.Common.Identity.Services;

public class UserSettingsService(IUserSettingsRepository userSettingsRepository) : IUserSettingsService
{
    public ValueTask<UserSettings?> GetByIdAsync(Guid userSettingsId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return userSettingsRepository.GetByIdAsync(userSettingsId, asNoTracking, cancellationToken);
    }

    public ValueTask<UserSettings> CreateAsync(UserSettings userSettings, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return userSettingsRepository.CreateAsync(userSettings, saveChanges, cancellationToken);
    }
}