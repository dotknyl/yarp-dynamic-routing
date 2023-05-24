using Yarp.DynamicRouting.Core.Commands;
using Yarp.DynamicRouting.Core.Entities;

namespace Yarp.DynamicRouting.Core.Interfaces.Repos
{
    public interface IDestinationRepo
    {
        Task<IEnumerable<Destination>> GetAllDestinations(int clusterId);
        Task<Destination?> GetDestination(int clusterId, int destinationId);
        Task<bool> AddDestination(int clusterId, UpsertDestinationCommand command);
        Task<bool> UpdateDestination(int clusterId, int destinationId, UpsertDestinationCommand command);
        Task<bool> DeleteDestination(int clusterId, int destinationId);
        Task<bool> DeleteDestinations(int clusterId);
    }
}