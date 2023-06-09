﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Yarp.DynamicRouting.Core.Common.Models;
using Yarp.DynamicRouting.Core.Entities;

namespace Yarp.DynamicRouting.Infrastructure.Db.Configuration;

public class ProxyRouteConfiguration : IEntityTypeConfiguration<ProxyRoute>
{
    public void Configure(EntityTypeBuilder<ProxyRoute> builder)
    {
        builder.ToTable(PgTables.ProxyRoute).HasKey(e => e.ProxyRouteId);
        builder.Property(e => e.Match)
                .HasColumnType("jsonb")
                .HasConversion(
                   v => JsonConvert.SerializeObject(v, Formatting.Indented),
                   v => JsonConvert.DeserializeObject<ProxyMatch>(v) ?? new ProxyMatch());
        builder.Property(e => e.Metadata)
                .HasColumnType("jsonb")
                .HasConversion(
                   v => JsonConvert.SerializeObject(v, Formatting.Indented),
                   v => JsonConvert.DeserializeObject<List<KeyValueItem>>(v));
        builder.Property(e => e.Transforms)
                .HasColumnType("jsonb")
                .HasConversion(
                   v => JsonConvert.SerializeObject(v, Formatting.Indented),
                   v => JsonConvert.DeserializeObject<List<Transform>>(v));

    }
}