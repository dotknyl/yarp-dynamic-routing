using System.ComponentModel;

namespace Yarp.DynamicRouting.Core.Enums;

public enum ClusterStatus
{
    [Description("Actived")]
    Actived = 1,
    [Description("Archived")]
    Archived,
    [Description("Maintaining")]
    Maintaining
}
