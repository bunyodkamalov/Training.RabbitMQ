using Training.RabbitMQ.Domain.Common.Caching;

namespace Training.RabbitMQ.Persistence.Caching.Brokers;

public interface ICacheBroker
{
    ValueTask<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default);

    ValueTask<bool> TryGetAsync<T>(string key, out T? value, CancellationToken cancellationToken = default);

    ValueTask<T?> GetOrSetAsync<T>(
        string key,
        Func<Task<T>> valueFactory,
        CacheEntryOptions? entryOptions = default,
        CancellationToken cancellationToken = default
    );

    ValueTask SetAsync<T>(string key, T value, CacheEntryOptions? entryOptions = default, CancellationToken cancellationToken = default);

    ValueTask DeleteAsync(string key, CancellationToken cancellationToken = default);
}