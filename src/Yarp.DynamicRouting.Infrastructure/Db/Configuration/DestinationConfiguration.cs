using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Yarp.DynamicRouting.Core.Common.Models;
using Yarp.DynamicRouting.Core.Entities;

namespace Yarp.DynamicRouting.Infrastructure.Db.Configuration;

public class DestinationConfiguration : IEntityTypeConfiguration<Destination>
{
    public void Configure(EntityTypeBuilder<Destination> builder)
    {
        builder.ToTable(PgTables.Destination).HasKey(e => e.Id);
        builder.Property(e => e.Metadata)
               .HasConversion(
                   v => JsonConvert.SerializeObject(v, Formatting.Indented),
                   v => JsonConvert.DeserializeObject<List<KeyValueItem>>(v));

    }
}

