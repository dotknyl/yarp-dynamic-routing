using Yarp.DynamicRouting.Core.Common.Models;
using Yarp.DynamicRouting.Core.Entities;

namespace Yarp.DynamicRouting.Core.Commands;

public record UpsertClusterCommand
{
    public string Name { get; set; }
    public string Status { get; set; }
    public string? LoadBalancingPolicy { get; set; }
    public SessionAffinityConfig? SessionAffinity { get; set; }
    public HealthCheckOptions? HealthCheck { get; set; }
    public HttpClientConfig? HttpClient { get; set; }
    public ForwarderRequest? HttpRequest { get; set; }
    public Dictionary<string, string>? Metadata { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}