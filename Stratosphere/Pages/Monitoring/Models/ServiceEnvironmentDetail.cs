namespace Stratosphere.Pages.Monitoring.Models;

public class ServiceEnvironmentDetail
{
	public int ServiceId { get; set; }
    public int EnvironmentId { get; set; }
    public bool AutomaticRestartEligible { get; set; }
    public int MinimumHealthStatusTypeIdForAction { get; set; }
    public int ConsecutiveFailuresBeforeAlert { get; set; }
    public int ConsecutiveFailuresBeforeRestart { get; set; }
}
