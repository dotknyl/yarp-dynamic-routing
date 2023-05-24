using Microsoft.EntityFrameworkCore;
using Yarp.DynamicRouting.Core.Commands;
using Yarp.DynamicRouting.Core.Common.Models;
using Yarp.DynamicRouting.Core.Entities;
using Yarp.DynamicRouting.Core.Interfaces.Db;
using Yarp.DynamicRouting.Core.Interfaces.Repos;
using Yarp.DynamicRouting.Core.Queries;

namespace Yarp.DynamicRouting.Infrastructure.Repos;
public class ClusterRepo : IClusterRepo
{
    private readonly IPgContext _pgContext;

    public ClusterRepo(IPgContext pgContext)
    {
        this._pgContext = pgContext;
    }

    public async Task<IEnumerable<Cluster>> GetClusters(FindClustersQuery query, int pageIndex, int pageSize)
    {
        var clustersQuery = _pgContext.Clusters.AsQueryable();

        //if (!string.IsNullOrEmpty(query.Name))
        //{
        //    clustersQuery = clustersQuery.Where(c => c.Name.Contains(query.Name));
        //}

        clustersQuery = clustersQuery.Skip(pageIndex * pageSize).Take(pageSize);

        return await clustersQuery.ToListAsync();
    }

    public async Task<Cluster?> GetCluster(int clusterId)
    {
        return await _pgContext.Clusters.FindAsync(clusterId);
    }

    public async Task<bool> AddCluster(UpsertClusterCommand command)
    {
        var cluster = new Cluster
        {
            UniqueId = Guid.NewGuid(),
            Name = command.Name,
            Status = command.Status,
            LoadBalancingPolicy = command.LoadBalancingPolicy,
            SessionAffinity = command.SessionAffinity,
            HealthCheck = command.HealthCheck,
            HttpClient = command.HttpClient,
            HttpRequest = command.HttpRequest,
            Metadata = command.Metadata?.ToKeyValueItems().ToList(),
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow
        };

        await _pgContext.Clusters.AddAsync(cluster);
        var rowsAffected = await _pgContext.SaveChangesAsync();
        return rowsAffected > 0;
    }

    public async Task<bool> UpdateCluster(int clusterId, UpsertClusterCommand command)
    {
        var cluster = await _pgContext.Clusters.FindAsync(clusterId);

        if (cluster is not { })
            return false;
        cluster.Name = command.Name;
        cluster.Status = command.Status;
        cluster.LoadBalancingPolicy = command.LoadBalancingPolicy;
        cluster.SessionAffinity = command.SessionAffinity;
        cluster.HealthCheck = command.HealthCheck;
        cluster.HttpClient = command.HttpClient;
        cluster.HttpRequest = command.HttpRequest;
        cluster.Metadata = command.Metadata?.ToKeyValueItems().ToList();
        cluster.UpdatedDate = DateTime.UtcNow;

        var rowsAffected = await _pgContext.SaveChangesAsync();
        return rowsAffected > 0;
    }

    public async Task<bool> DeleteCluster(int clusterId)
    {
        var cluster = await _pgContext.Clusters.FindAsync(clusterId);

        if (cluster is not { })
            return false;

        _pgContext.Clusters.Remove(cluster);
        var rowsAffected = await _pgContext.SaveChangesAsync();
        return rowsAffected > 0;
    }
}
