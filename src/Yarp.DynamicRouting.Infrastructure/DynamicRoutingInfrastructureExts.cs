using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Yarp.DynamicRouting.Core.Interfaces.Db;
using Yarp.DynamicRouting.Infrastructure.Db;

namespace Yarp.DynamicRouting.Infrastructure;
public static class DynamicRoutingInfrastructureExts
{
    public static IServiceCollection ConfigDynamicRoutingInfrastructure(this IServiceCollection services, string pgConn)
    {
        string assemblyName = typeof(PgContext).Assembly.GetName().Name ?? string.Empty;
        services.AddDbContext<PgContext>(options => options.UseNpgsql(pgConn,
            db => db
            .MigrationsAssembly(assemblyName)
            .MigrationsHistoryTable("public", "public")
        ).UseSnakeCaseNamingConvention());

        services.AddScoped<IPgContext>(provider => provider.GetService<IPgContext>());

        return services;
    }
}

