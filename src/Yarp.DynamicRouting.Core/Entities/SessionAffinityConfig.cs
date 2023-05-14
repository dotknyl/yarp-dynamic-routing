using Microsoft.AspNetCore.Http;

namespace Yarp.DynamicRouting.Core.Entities;

public class SessionAffinityConfig
{

    /// <summary>
    /// Indicates whether session affinity is enabled.
    /// </summary>
    public bool? Enabled { get; init; }

    /// <summary>
    /// The session affinity policy to use.
    /// </summary>
    public string? Policy { get; init; }

    /// <summary>
    /// Strategy handling missing destination for an affinitized request.
    /// </summary>
    public string? FailurePolicy { get; init; }

    /// <summary>
    /// Identifies the name of the field where the affinity value is stored.
    /// For the cookie affinity policy this will be the cookie name.
    /// For the header affinity policy this will be the header name.
    /// The policy will give its own default if no value is set.
    /// This value should be unique across clusters to avoid affinity conflicts.
    /// https://github.com/microsoft/reverse-proxy/issues/976
    /// This field is required.
    /// </summary>
    public string AffinityKeyName { get; init; } = default!;

    /// <summary>
    /// Configuration of a cookie storing the session affinity key in case
    /// the <see cref="Policy"/> is set to 'Cookie'.
    /// </summary>
    public SessionAffinityCookie? Cookie { get; init; }

    public string? ClusterId { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public bool Equals(SessionAffinityConfig? other)
    {
        if (other == null)
        {
            return false;
        }

        return Enabled == other.Enabled
            && string.Equals(Policy, other.Policy, StringComparison.OrdinalIgnoreCase)
            && string.Equals(FailurePolicy, other.FailurePolicy, StringComparison.OrdinalIgnoreCase)
            && string.Equals(AffinityKeyName, other.AffinityKeyName, StringComparison.Ordinal)
            && Cookie == other.Cookie;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Enabled,
            Policy?.GetHashCode(StringComparison.OrdinalIgnoreCase),
            FailurePolicy?.GetHashCode(StringComparison.OrdinalIgnoreCase),
            AffinityKeyName?.GetHashCode(StringComparison.Ordinal),
            Cookie);
    }
}

public class SessionAffinityCookie
{
    /// <summary>
    /// The cookie path.
    /// </summary>
    public string? Path { get; init; }

    /// <summary>
    /// The domain to associate the cookie with.
    /// </summary>
    public string? Domain { get; init; }

    /// <summary>
    /// Indicates whether a cookie is accessible by client-side script.
    /// </summary>
    /// <remarks>Defaults to "true".</remarks>
    public bool? HttpOnly { get; init; }

    /// <summary>
    /// The policy that will be used to determine <see cref="CookieOptions.Secure"/>.
    /// </summary>
    /// <remarks>Defaults to <see cref="CookieSecurePolicy.None"/>.</remarks>
    public CookieSecurePolicy? SecurePolicy { get; init; }

    /// <summary>
    /// The SameSite attribute of the cookie.
    /// </summary>
    /// <remarks>Defaults to <see cref="SameSiteMode.Unspecified"/>.</remarks>
    public SameSiteMode? SameSite { get; init; }

    /// <summary>
    /// Gets or sets the lifespan of a cookie.
    /// </summary>
    public string? Expiration { get; init; }

    /// <summary>
    /// Gets or sets the max-age for the cookie.
    /// </summary>
    public string? MaxAge { get; init; }

    /// <summary>
    /// Indicates if this cookie is essential for the application to function correctly. If true then
    /// consent policy checks may be bypassed.
    /// </summary>
    /// <remarks>Defaults to "false".</remarks>
    public bool? IsEssential { get; init; }

    public int SessionAffinityConfigId { get; init; }
    public virtual SessionAffinityConfig? SessionAffinityConfig { get; init; }

    public bool Equals(SessionAffinityCookie? other)
    {
        if (other == null)
        {
            return false;
        }

        return string.Equals(Path, other.Path, StringComparison.Ordinal)
            && string.Equals(Domain, other.Domain, StringComparison.OrdinalIgnoreCase)
            && HttpOnly == other.HttpOnly
            && SecurePolicy == other.SecurePolicy
            && SameSite == other.SameSite
            && Expiration == other.Expiration
            && MaxAge == other.MaxAge
            && IsEssential == other.IsEssential;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Path?.GetHashCode(StringComparison.Ordinal),
            Domain?.GetHashCode(StringComparison.OrdinalIgnoreCase),
            HttpOnly,
            SecurePolicy,
            SameSite,
            Expiration,
            MaxAge,
            IsEssential);
    }
}
