using Stratosphere.Pages.Administration.Queues.ViewModels;

namespace Stratosphere.Pages.Administration.Queues.Services;

public class QueueAdminService : IQueueAdminService
{
    public async Task<List<QueueVM>?> GetQueues()
    {
        var retVal = new List<QueueVM>();

        return retVal;
    }
}
