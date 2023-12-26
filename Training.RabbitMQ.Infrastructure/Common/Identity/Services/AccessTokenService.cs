using Training.RabbitMQ.Application.Common.Identity.Services;
using Training.RabbitMQ.Domain.Entities.Subs;
using Training.RabbitMQ.Persistence.Repositories.Interfaces;

namespace Training.RabbitMQ.Infrastructure.Common.Identity.Services;

public class AccessTokenService(IAccessTokenRepository accessTokenRepository) : IAccessTokenService
{
    public ValueTask<AccessToken> CreateAsync(AccessToken accessToken, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return accessTokenRepository.CreateAsync(accessToken, saveChanges, cancellationToken);
    }
    
    public ValueTask<AccessToken?> GetByIdAsync(Guid accessTokenId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return accessTokenRepository.GetByIdAsync(accessTokenId, cancellationToken);
    }

    public async ValueTask RevokeAsync(Guid accessTokenId, CancellationToken cancellationToken = default)
    {
        var accessToken = await GetByIdAsync(accessTokenId, cancellationToken: cancellationToken);
        if (accessToken is null) throw new InvalidOperationException($"Access token with id {accessTokenId} not found.");

        accessToken.IsRevoked = true;
        await accessTokenRepository.UpdateAsync(accessToken, cancellationToken);
    }
}
