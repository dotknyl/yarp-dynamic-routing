using Yarp.DynamicRouting.Core.Commands;
using Yarp.DynamicRouting.Core.Entities;
using Yarp.DynamicRouting.Core.Queries;

namespace Yarp.DynamicRouting.Core.Interfaces.Repos
{
    public interface IClusterRepo
    {
        Task<IEnumerable<Cluster>> GetClusters(FindClustersQuery query);
        Task<Cluster> GetCluster(int clusterId);
        Task<bool> AddCluster(AddClusterCommand command);
        Task<bool> UpdateCluster(int clusterId, UpdateClusterCommand command);
        Task<bool> DeleteCluster(int clusterId);
    }
}
