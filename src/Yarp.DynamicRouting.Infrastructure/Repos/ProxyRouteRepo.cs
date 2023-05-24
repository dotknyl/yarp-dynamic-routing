using Microsoft.EntityFrameworkCore;
using Yarp.DynamicRouting.Core.Commands;
using Yarp.DynamicRouting.Core.Common.Models;
using Yarp.DynamicRouting.Core.Entities;
using Yarp.DynamicRouting.Core.Interfaces.Db;
using Yarp.DynamicRouting.Core.Interfaces.Repos;

namespace Yarp.DynamicRouting.Infrastructure.Repos;

public class ProxyRouteRepo : IProxyRouteRepo
{
    private readonly IPgContext _pgContext;

    public ProxyRouteRepo(IPgContext pgContext)
    {
        this._pgContext = pgContext;
    }

    public async Task<IEnumerable<ProxyRoute>> GetAllProxyRoutes(int clusterId)
    {
        return await _pgContext.ProxyRoutes
            .Where(r => r.ClusterId == clusterId)
            .ToListAsync();
    }

    public async Task<ProxyRoute?> GetProxyRoute(int clusterId, int proxyRouteId)
    {
        return await _pgContext.ProxyRoutes
            .FirstOrDefaultAsync(r => r.ClusterId == clusterId && r.ProxyRouteId == proxyRouteId);
    }

    public async Task<bool> AddProxyRoute(int clusterId, UpsertProxyRouteCommand command)
    {
        var proxyRoute = new ProxyRoute
        {
            ClusterId = clusterId,
            RouteId = Guid.NewGuid().ToString(),
            Match = command.Match,
            Order = command.Order,
            AuthorizationPolicy = command.AuthorizationPolicy,
            CorsPolicy = command.CorsPolicy,
            Metadata = command.Metadata?.ToKeyValueItems().ToList(),
            Transforms = command.Transforms,
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow
        };

        await _pgContext.ProxyRoutes.AddAsync(proxyRoute);
        var rowsAffected = await _pgContext.SaveChangesAsync();
        return rowsAffected > 0;
    }

    public async Task<bool> UpdateProxyRoute(int clusterId, int proxyRouteId, UpsertProxyRouteCommand command)
    {
        var proxyRoute = await _pgContext.ProxyRoutes
            .FirstOrDefaultAsync(r => r.ClusterId == clusterId && r.ProxyRouteId == proxyRouteId);

        if (proxyRoute == null)
            return false;
        proxyRoute.RouteId = Guid.NewGuid().ToString();
        proxyRoute.Match = command.Match;
        proxyRoute.Order = command.Order;
        proxyRoute.AuthorizationPolicy = command.AuthorizationPolicy;
        proxyRoute.CorsPolicy = command.CorsPolicy;
        proxyRoute.Metadata = command.Metadata?.ToKeyValueItems().ToList();
        proxyRoute.Transforms = command.Transforms;

        // Update other properties

        // Update UpdatedDate
        proxyRoute.UpdatedDate = DateTime.UtcNow;

        var rowsAffected = await _pgContext.SaveChangesAsync();
        return rowsAffected > 0;
    }

    public async Task<bool> DeleteProxyRoute(int clusterId, int proxyRouteId)
    {
        var proxyRoute = await _pgContext.ProxyRoutes
            .FirstOrDefaultAsync(r => r.ClusterId == clusterId && r.ProxyRouteId == proxyRouteId);

        if (proxyRoute == null)
            return false;

        _pgContext.ProxyRoutes.Remove(proxyRoute);
        var rowsAffected = await _pgContext.SaveChangesAsync();
        return rowsAffected > 0;
    }

    public async Task<bool> DeleteProxyRoutes(int clusterId)
    {
        var proxyRoutes = await _pgContext.ProxyRoutes.Where(r => r.ClusterId == clusterId).ToListAsync();

        _pgContext.ProxyRoutes.RemoveRange(proxyRoutes);
        var rowsAffected = await _pgContext.SaveChangesAsync();
        return rowsAffected > 0;
    }
}

