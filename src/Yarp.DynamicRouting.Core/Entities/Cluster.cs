using System.ComponentModel.DataAnnotations;
using Yarp.DynamicRouting.Core.Common.Models;

namespace Yarp.DynamicRouting.Core.Entities;
public class Cluster
{
    /// <summary>
    /// The Id for this cluster. This needs to be globally unique.
    /// </summary>
    [Key]
    public int Id { get; set; }
    public Guid UniqueId { get; set; }
    public required string Name { get; set; }
    public required string Status { get; set; }
    /// <summary>
    /// Load balancing policy.
    /// </summary>
    public string? LoadBalancingPolicy { get; set; }

    /// <summary>
    /// Session affinity options.
    /// </summary>
    public SessionAffinityConfig? SessionAffinity { get; set; }

    /// <summary>
    /// Health checking options.
    /// </summary>
    public HealthCheckOptions? HealthCheck { get; set; }

    /// <summary>
    /// Options of an HTTP client that is used to call this cluster.
    /// </summary>
    public HttpClientConfig? HttpClient { get; set; }

    /// <summary>
    /// Options of an outgoing HTTP request.
    /// </summary>
    public ForwarderRequest? HttpRequest { get; set; }

    /// <summary>
    /// The set of destinations associated with this cluster.
    /// </summary>
    //public virtual List<Destination>? Destinations { get; set; }

    /// <summary>
    /// Arbitrary key-value pairs that further describe this cluster.
    /// </summary>
    public List<KeyValueItem>? Metadata { get; set; }

    // public virtual List<ProxyRoute>? ProxyRoutes { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
