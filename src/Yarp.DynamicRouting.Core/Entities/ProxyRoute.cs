using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Yarp.DynamicRouting.Core.Common.Models;
using Yarp.DynamicRouting.Core.Enums;

namespace Yarp.DynamicRouting.Core.Entities;
/// <summary>
/// Describes a route that matches incoming requests based on a the <see cref="Match"/> criteria
/// and proxies matching requests to the cluster identified by its <see cref="ClusterId"/>.
/// </summary>
public class ProxyRoute
{
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// Globally unique identifier of the route.
    /// </summary>
    public string? RouteId { get; set; }

    /// <summary>
    /// Parameters used to match requests.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public ProxyMatch Match { get; set; }

    /// <summary>
    /// Optionally, an order value for this route. Routes with lower numbers take precedence over higher numbers.
    /// </summary>
    public int? Order { get; set; }

    /// <summary>
    /// Gets or sets the cluster that requests matching this route
    /// should be proxied to.
    /// </summary>
    public int ClusterId { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    /// <summary>
    /// The name of the AuthorizationPolicy to apply to this route.
    /// If not set then only the FallbackPolicy will apply.
    /// Set to "Default" to enable authorization with the applications default policy.
    /// Set to "Anonymous" to disable all authorization checks for this route.
    /// </summary>
    public string? AuthorizationPolicy { get; set; }

    /// <summary>
    /// The name of the CorsPolicy to apply to this route.
    /// If not set then the route won't be automatically matched for cors preflight requests.
    /// Set to "Default" to enable cors with the default policy.
    /// Set to "Disable" to refuses cors requests for this route.
    /// </summary>
    public string? CorsPolicy { get; set; }

    /// <summary>
    /// Arbitrary key-value pairs that further describe this route.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<KeyValueItem>? Metadata { get; set; }

    /// <summary>
    /// Parameters used to transform the request and response. See <see cref="Service.ITransformBuilder"/>.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<Transform>? Transforms { get; set; }

}

public class Transform : KeyValueItem
{
    public TransformType Type { get; set; }
}

