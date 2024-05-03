using Stratosphere.Pages.Queues.Models;

namespace Stratosphere.Services.Queues;

public interface IQueueApiService
{
    //TODO: change strings to more specific types based on the expected response
    Task<List<Queue>?> GetAllQueueInfo(bool minimizeResults);
    Task<string?> GetAllQueueInfoByVHost(string? vhost);
    Task<string?> GetQueueInfo(string? vhost, string? queueName);
}
