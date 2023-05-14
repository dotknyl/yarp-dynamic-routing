namespace Yarp.DynamicRouting.Core.Entities;
public class HealthCheckOptions
{

    /// <summary>
    /// Passive health check options.
    /// </summary>
    public PassiveHealthCheckOptions? Passive { get; init; }

    /// <summary>
    /// Active health check options.
    /// </summary>
    public ActiveHealthCheckOptions? Active { get; init; }
    /// <summary>
    /// Available destinations policy.
    /// </summary>
    public string? AvailableDestinationsPolicy { get; init; }

    public string? ClusterId { get; set; }

    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
public class ActiveHealthCheckOptions
{
    public bool? Enabled { get; set; }

    /// <summary>
    /// Health probe interval.
    /// </summary>
    public string? Interval { get; set; }

    /// <summary>
    /// Health probe timeout, after which a destination is considered unhealthy.
    /// </summary>
    public string? Timeout { get; set; }

    /// <summary>
    /// Active health check policy.
    /// </summary>
    public string? Policy { get; set; }

    /// <summary>
    /// HTTP health check endpoint path.
    /// </summary>
    public string? Path { get; set; }
}

public class PassiveHealthCheckOptions
{
    /// <summary>
    /// Whether passive health checks are enabled.
    /// </summary>
    public bool? Enabled { get; set; }

    /// <summary>
    /// Passive health check policy.
    /// </summary>
    public string? Policy { get; set; }

    /// <summary>
    /// Destination reactivation period after which an unhealthy destination is considered healthy again.
    /// </summary>
    public string? ReactivationPeriod { get; set; }
    public int HealthCheckOptionsId { get; set; }
}
