using Microsoft.EntityFrameworkCore;
using Yarp.DynamicRouting.Core.Entities;
using Yarp.DynamicRouting.Core.Interfaces.Db;
using Yarp.DynamicRouting.Infrastructure.Db.Configuration;

namespace Yarp.DynamicRouting.Infrastructure.Db;

public class PgContext : DbContext, IPgContext
{
    public PgContext(DbContextOptions<PgContext> options) : base(options)
    {
    }
    public virtual DbSet<Cluster> Clusters { get; set; }
    public virtual DbSet<Destination> Destinations { get; set; }
    public virtual DbSet<ProxyRoute> ProxyRoutes { get; set; }

    string IPgContext.GetConnectionString()
    {
        return Database.GetConnectionString() ?? throw new ArgumentNullException();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ClusterConfiguration());
        builder.ApplyConfiguration(new DestinationConfiguration());
        builder.ApplyConfiguration(new ProxyRouteConfiguration());
        base.OnModelCreating(builder);
    }
}
