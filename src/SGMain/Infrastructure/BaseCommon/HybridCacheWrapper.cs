using Microsoft.Extensions.Caching.Hybrid;

namespace Infrastructure;

public class HybridCacheWrapper : IHybridCache
{
    private readonly HybridCache _inner;
    public HybridCacheWrapper(HybridCache inner)
    {
        _inner = inner;
    }
    public Task<T> GetOrCreateAsync<T>(string key, Func<CancellationToken, ValueTask<T>> factory, HybridCacheEntryOptions? options = null, IEnumerable<string>? tags = null, CancellationToken cancellationToken = default)
    {
        return _inner.GetOrCreateAsync(key, factory, options, tags, cancellationToken).AsTask();
    }
}