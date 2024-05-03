using Stratosphere.Pages.Queues.Models;

namespace Stratosphere.Pages.Queues.ViewModels;

public class QueueIndexViewModel
{
    public List<EnvironmentGroup>? EnvironmentGroups { get; set; }
    public List<Queue>? Queues { get; set; }
}
