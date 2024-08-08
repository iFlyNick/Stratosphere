using Stratosphere.Pages.Administration.Queues.ViewModels;

namespace Stratosphere.Pages.Administration.Queues.Services;

public interface IQueueAdminService
{
    Task<List<QueueVM>?> GetQueues();
}
