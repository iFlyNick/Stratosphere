namespace Stratosphere.Pages.Queues.Models;

public class MessageQueueApiSettings
{
    public string? Hostname { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? BaseUrl { get; set; }
    public Dictionary<string, string>? EndpointUris { get; set; }
}
