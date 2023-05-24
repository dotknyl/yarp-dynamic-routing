using Yarp.DynamicRouting.Core.Common.Models;
using Yarp.DynamicRouting.Core.Entities;

namespace Yarp.DynamicRouting.Core.Commands;

public record UpsertProxyRouteCommand
{
    public ProxyMatch Match { get; set; }
    public int? Order { get; set; }
    public string? AuthorizationPolicy { get; set; }
    public string? CorsPolicy { get; set; }
    public Dictionary<string,string>? Metadata { get; set; }
    public List<Transform>? Transforms { get; set; }
}