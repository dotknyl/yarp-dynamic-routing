using Yarp.DynamicRouting.Core.Commands;
using Yarp.DynamicRouting.Core.Entities;

namespace Yarp.DynamicRouting.Core.Interfaces.Repos;

public interface IProxyRouteRepo
{
    Task<IEnumerable<ProxyRoute>> GetAllProxyRoutes(int clusterId);
    Task<ProxyRoute?> GetProxyRoute(int clusterId, int proxyRouteId);
    Task<bool> AddProxyRoute(int clusterId, UpsertProxyRouteCommand command);
    Task<bool> UpdateProxyRoute(int clusterId, int proxyRouteId, UpsertProxyRouteCommand command);
    Task<bool> DeleteProxyRoute(int clusterId, int proxyRouteId);
    Task<bool> DeleteProxyRoutes(int clusterId);
}