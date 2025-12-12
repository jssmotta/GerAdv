using Microsoft.Extensions.Caching.Hybrid;

namespace Infrastructure;

public interface IHybridCache
{
    Task<T> GetOrCreateAsync<T>(
        string key,
        Func<CancellationToken, ValueTask<T>> factory,
        HybridCacheEntryOptions? options = null,
        IEnumerable<string>? tags = null,
        CancellationToken cancellationToken = default);
}
