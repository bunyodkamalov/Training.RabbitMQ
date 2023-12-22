using Training.RabbitMQ.Domain.Common.Caching;
using Training.RabbitMQ.Domain.Entities.Subs;
using Training.RabbitMQ.Persistence.Caching.Brokers;
using Training.RabbitMQ.Persistence.Repositories.Interfaces;

namespace Training.RabbitMQ.Persistence.Repositories;

public class AccessTokenRepository(ICacheBroker cacheBroker) : IAccessTokenRepository
{
    public async ValueTask<AccessToken> CreateAsync(AccessToken accessToken, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var cacheEntryOptions = new CacheEntryOptions(accessToken.ExpiryTime - DateTimeOffset.UtcNow, null);
        await cacheBroker.SetAsync(accessToken.Id.ToString(), accessToken, cacheEntryOptions, cancellationToken);

        return accessToken;
    }

    public ValueTask<AccessToken?> GetByIdAsync(Guid accessTokenId, CancellationToken cancellationToken = default)
    {
        return cacheBroker.GetAsync<AccessToken>(accessTokenId.ToString(), cancellationToken);
    }

    public async ValueTask<AccessToken> UpdateAsync(AccessToken accessToken, CancellationToken cancellationToken = default)
    {
        var cacheEntryOptions = new CacheEntryOptions(accessToken.ExpiryTime - DateTimeOffset.UtcNow, null);
        await cacheBroker.SetAsync(accessToken.Id.ToString(), accessToken, cacheEntryOptions, cancellationToken);

        return accessToken;
    }
}