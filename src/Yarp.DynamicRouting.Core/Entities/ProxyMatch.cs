using Yarp.ReverseProxy.Configuration;

namespace Yarp.DynamicRouting.Core.Entities;
public class ProxyMatch
{
    /// <summary>
    /// Only match requests that use these optional HTTP methods. E.g. GET, POST.
    /// </summary>
    public string? Methods { get; set; }

    /// <summary>
    /// Only match requests with the given Host header.
    /// </summary>
    public string? Hosts { get; set; }

    /// <summary>
    /// Only match requests with the given Path pattern.
    /// </summary>
    public string? Path { get; set; }

    /// <summary>
    /// Only match requests that contain all of these query parameters.
    /// </summary>
    public List<RouteQueryParameter>? QueryParameters { get; set; }

    public List<RouteHeader>? Headers { get; set; }
}

public class RouteQueryParameter
{

    /// <summary>
    /// Name of the query parameter to look for.
    /// This field is case insensitive and required.
    /// </summary>
    public string Name { get; init; } = default!;

    /// <summary>
    /// A collection of acceptable query parameter values used during routing.
    /// </summary>
    public string? Values { get; init; }

    /// <summary>
    /// Specifies how query parameter values should be compared (e.g. exact matches Vs. contains).
    /// Defaults to <see cref="QueryParameterMatchMode.Exact"/>.
    /// </summary>
    public QueryParameterMatchMode Mode { get; init; }

    /// <summary>
    /// Specifies whether query parameter value comparisons should ignore case.
    /// When <c>true</c>, <see cref="StringComparison.Ordinal" /> is used.
    /// When <c>false</c>, <see cref="StringComparison.OrdinalIgnoreCase" /> is used.
    /// Defaults to <c>false</c>.
    /// </summary>
    public bool IsCaseSensitive { get; init; }
}



public class RouteHeader
{
    public string? Name { get; set; }

    /// <summary>
    /// A collection of acceptable header values used during routing. Only one value must match.
    /// The list must not be empty unless using <see cref="HeaderMatchMode.Exists"/>.
    /// </summary>
    public string? Values { get; set; }

    /// <summary>
    /// Specifies how header values should be compared (e.g. exact matches Vs. by prefix).
    /// Defaults to <see cref="HeaderMatchMode.ExactHeader"/>.
    /// </summary>
    public HeaderMatchMode Mode { get; set; }

    /// <summary>
    /// Specifies whether header value comparisons should ignore case.
    /// When <c>true</c>, <see cref="StringComparison.Ordinal" /> is used.
    /// When <c>false</c>, <see cref="StringComparison.OrdinalIgnoreCase" /> is used.
    /// Defaults to <c>false</c>.
    /// </summary>
    public bool IsCaseSensitive { get; set; }
}