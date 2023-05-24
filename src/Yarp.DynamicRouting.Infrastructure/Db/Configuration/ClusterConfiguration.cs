using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Yarp.DynamicRouting.Core.Common.Models;
using Yarp.DynamicRouting.Core.Entities;

namespace Yarp.DynamicRouting.Infrastructure.Db.Configuration;

public class ClusterConfiguration : IEntityTypeConfiguration<Cluster>
{
    public void Configure(EntityTypeBuilder<Cluster> builder)
    {
        builder.ToTable(PgTables.Cluster).HasKey(e => e.ClusterId);
        builder.Property(e => e.SessionAffinity)
                .HasColumnType("jsonb")
                .HasConversion(
                   v => JsonConvert.SerializeObject(v, Formatting.Indented),
                   v => JsonConvert.DeserializeObject<SessionAffinityConfig>(v));
        builder.Property(e => e.HealthCheck)
                .HasColumnType("jsonb")
                .HasConversion(
                   v => JsonConvert.SerializeObject(v, Formatting.Indented),
                   v => JsonConvert.DeserializeObject<HealthCheckOptions>(v));
        builder.Property(e => e.HttpClient)
                .HasColumnType("jsonb")
                .HasConversion(
                   v => JsonConvert.SerializeObject(v, Formatting.Indented),
                   v => JsonConvert.DeserializeObject<HttpClientConfig>(v));
        builder.Property(e => e.HttpRequest)
                .HasColumnType("jsonb")
                .HasConversion(
                   v => JsonConvert.SerializeObject(v, Formatting.Indented),
                   v => JsonConvert.DeserializeObject<ForwarderRequest>(v));
        builder.Property(e => e.Metadata)
                .HasColumnType("jsonb")
                .HasConversion(
                   v => JsonConvert.SerializeObject(v, Formatting.Indented),
                   v => JsonConvert.DeserializeObject<List<KeyValueItem>>(v));

    }
}
