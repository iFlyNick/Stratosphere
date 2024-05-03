namespace Stratosphere.Pages.Monitoring.Models;

public class Service
{
	public int ServiceId { get; set; }
	public string? ServiceName { get; set; }
	public string? ServiceDescription { get; set; }
	public string? ServiceType { get; set; }
	public ServiceEnvironmentDetail? ServiceEnvironmentDetail { get; set; }
}
