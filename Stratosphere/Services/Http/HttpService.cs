using System.Net.Http.Headers;

namespace Stratosphere.Services.Http;

public class HttpService : IHttpService
{
    private readonly HttpClient _httpClient;
    
    public HttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    private void ConfigureClient(string? method, string? url, HttpContent? content, string? contentType, AuthenticationHeaderValue? authHeader, Dictionary<string, string>? headers)
    {
        //TODO: figure out what happens if two methods are trying to modify the same instance as this should end up being transient from DI and multiple requests at the same time could access the same instance

        ArgumentException.ThrowIfNullOrEmpty(method, nameof(method));
        ArgumentException.ThrowIfNullOrEmpty(url, nameof(url));

        if (!method.Equals("GET"))
        {
            ArgumentNullException.ThrowIfNull(content, nameof(content));
            ArgumentException.ThrowIfNullOrEmpty(contentType, nameof(contentType));
        }

        _httpClient.DefaultRequestHeaders.Clear();

        if (!string.IsNullOrEmpty(contentType))
            _httpClient.DefaultRequestHeaders.Add("Content-Type", contentType);

        if (headers?.Keys?.Any() ?? false)
            foreach (var key in headers.Keys)
                _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(key, headers[key]);

        _httpClient.DefaultRequestHeaders.Authorization = authHeader;
    }

    public async Task<HttpResponseMessage?> GetAsync(string? url, AuthenticationHeaderValue? authHeader, Dictionary<string, string>? headers, CancellationToken cancellationToken = default)
    {
        ConfigureClient("GET", url, null, string.Empty, authHeader, headers);
        return await _httpClient.GetAsync(new Uri(url!), cancellationToken);
    }

    public async Task<HttpResponseMessage?> PostAsync(string? url, HttpContent? content, string? contentType, AuthenticationHeaderValue? authHeader, Dictionary<string, string>? headers, CancellationToken cancellationToken = default)
    {
        ConfigureClient("POST", url, content, contentType, authHeader, headers);
        return await _httpClient.PostAsync(new Uri(url!), content, cancellationToken);
    }

    public async Task<HttpResponseMessage?> PutAsync(string? url, HttpContent? content, string? contentType, AuthenticationHeaderValue? authHeader, Dictionary<string, string>? headers, CancellationToken cancellationToken = default)
    {
        ConfigureClient("PUT", url, content, contentType, authHeader, headers);
        return await _httpClient.PutAsync(new Uri(url!), content, cancellationToken);
    }

    public async Task<HttpResponseMessage?> PatchAsync(string? url, HttpContent? content, string? contentType, AuthenticationHeaderValue? authHeader, Dictionary<string, string>? headers, CancellationToken cancellationToken = default)
    {
        ConfigureClient("PATCH", url, content, contentType, authHeader, headers);
        return await _httpClient.PatchAsync(new Uri(url!), content, cancellationToken);
    }

    public async Task<HttpResponseMessage?> DeleteAsync(string? url, AuthenticationHeaderValue? authHeader, Dictionary<string, string>? headers, CancellationToken cancellationToken = default)
    {
        ConfigureClient("DELETE", url, null, string.Empty, authHeader, headers);
        return await _httpClient.DeleteAsync(new Uri(url!), cancellationToken);
    }
}
