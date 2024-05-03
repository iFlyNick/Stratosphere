using Newtonsoft.Json;

namespace Stratosphere.Pages.Queues.Models;

public class Queue
{
    public string? Name { get; set; }
    public string? VHost { get; set; }
    public string? Type { get; set; }
    public string? State { get; set; }
    public int Messages { get; set; }
    [JsonProperty("messages_unacknowledged")]
    public int UnacknowledgedMessages { get; set; }
    public int Consumers { get; set; }
}
