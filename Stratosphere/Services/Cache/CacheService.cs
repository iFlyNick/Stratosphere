using Microsoft.Extensions.Caching.Memory;

namespace Stratosphere.Services.Cache;

public class CacheService(ILogger<CacheService> logger, IMemoryCache memoryCache) : ICacheService
{
    private readonly ILogger<CacheService> _logger = logger;
    private readonly IMemoryCache _memoryCache = memoryCache;

    public object? GetCacheEntry(string? key)
    {
        if (string.IsNullOrEmpty(key))
            return null;

        if (_memoryCache.TryGetValue(key, out object? value))
            return value;

        return null;
    }

    public void RefreshCacheEntry(string? key, object? value)
    {
        if (string.IsNullOrEmpty(key))
            return;

        RemoveCacheEntry(key);
        AddCacheEntry(key, value);
    }

    public void AddCacheEntry(string? key, object? value)
    {
        if (string.IsNullOrEmpty(key) || value is null)
            return;

        _memoryCache.Set(key, value);
    }

    public void RemoveCacheEntry(string? key)
    {
        if (string.IsNullOrEmpty(key))
            return;

        _memoryCache.Remove(key);
    }
}
