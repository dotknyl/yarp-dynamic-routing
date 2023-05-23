namespace Yarp.DynamicRouting.Core.Commands;

public record UpsertDestinationCommand
{
    public string Address { get; set; }
    public string? Health { get; set; }
    public Dictionary<string, string>? Metadata { get; set; }
}