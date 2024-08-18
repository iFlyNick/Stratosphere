using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Stratosphere.Pages.Queues.Models;
using Stratosphere.Services.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Stratosphere.Services.Queues;

public class QueueApiService(ILogger<QueueApiService> logger, IHttpService httpService, IOptions<MessageQueueApiSettings> settings) : IQueueApiService
{
    private readonly ILogger<QueueApiService> _logger = logger;
    private readonly IHttpService _httpService = httpService;
    private readonly MessageQueueApiSettings _settings = settings.Value;

    public async Task<List<Queue>?> GetAllQueueInfo(bool minimizeResults)
    {
        var endpoint = minimizeResults ? _settings.EndpointUris?.GetValueOrDefault("QueuesMinimized") : _settings.EndpointUris?.GetValueOrDefault("Queues");
        var url = $"{_settings.BaseUrl}{endpoint}";
        var auth = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_settings.Username}:{_settings.Password}")));

        try
        {
            var resp = await _httpService.GetAsync(url, auth, null);

            if (resp?.IsSuccessStatusCode ?? false)
            {
                var respVal = await resp.Content.ReadAsStringAsync();
                var queueInfo = JsonConvert.DeserializeObject<List<Queue>>(respVal);

                return queueInfo;
            }
        } 
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        return null;
    }

    public async Task<string?> GetAllQueueInfoByVHost(string? vhost)
    {
        return string.Empty;
    }

    public async Task<string?> GetQueueInfo(string? vhost, string? queueName)
    {
        return string.Empty;
    }
}
