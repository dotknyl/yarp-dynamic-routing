using Microsoft.EntityFrameworkCore;
using Yarp.DynamicRouting.Core.Entities;

namespace Yarp.DynamicRouting.Core.Interfaces.Db;

public interface IPgContext
{
    DbSet<Cluster> Clusters { get; }
    DbSet<Destination> Destinations { get; }
    DbSet<ProxyRoute> ProxyRoutes { get; }

    string GetConnectionString();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
}