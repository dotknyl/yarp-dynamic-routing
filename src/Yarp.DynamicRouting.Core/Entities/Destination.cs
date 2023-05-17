using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Yarp.DynamicRouting.Core.Common.Models;

namespace Yarp.DynamicRouting.Core.Entities;

/// <summary>
/// Describes a destination of a cluster.
/// </summary>
public class Destination
{
    [Key]
    public int Id { get; set; }
    /// <summary>
    /// Address of this destination. E.g. <c>https://127.0.0.1:123/abcd1234/</c>.
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Endpoint accepting active health check probes. E.g. <c>http://127.0.0.1:1234/</c>.
    /// </summary>
    public string? Health { get; set; }
    public int ClusterId { get; set; }
    public DateTime? CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    /// <summary>
    /// Arbitrary key-value pairs that further describe this destination.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<KeyValueItem>? Metadata { get; set; }
}
