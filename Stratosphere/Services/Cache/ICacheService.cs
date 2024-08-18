namespace Stratosphere.Services.Cache;

public interface ICacheService
{
    object? GetCacheEntry(string? key);
    void AddCacheEntry(string? key, object? value);
    void RemoveCacheEntry(string? key);
    void RefreshCacheEntry(string? key, object? value);
}
