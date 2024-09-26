namespace Stratosphere.Pages.Administration.Queues.ViewModels;

public class QueueProviderVM
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ProviderType { get; set; }
    public ConnectionProfileVM? ConnectionProfile { get; set; }
}
