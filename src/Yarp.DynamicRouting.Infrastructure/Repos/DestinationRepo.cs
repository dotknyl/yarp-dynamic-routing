using Microsoft.EntityFrameworkCore;
using Yarp.DynamicRouting.Core.Commands;
using Yarp.DynamicRouting.Core.Common.Models;
using Yarp.DynamicRouting.Core.Entities;
using Yarp.DynamicRouting.Core.Interfaces.Db;
using Yarp.DynamicRouting.Core.Interfaces.Repos;

namespace Yarp.DynamicRouting.Infrastructure.Repos;
public class DestinationRepo : IDestinationRepo
{
    private readonly IPgContext _dbContext;

    public DestinationRepo(IPgContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Destination>> GetAllDestinations(int clusterId)
    {
        return await _dbContext.Destinations.Where(d => d.ClusterId == clusterId).ToListAsync();
    }

    public async Task<Destination?> GetDestination(int clusterId, int destinationId)
    {
        return await _dbContext.Destinations.FirstOrDefaultAsync(d => d.ClusterId == clusterId && d.DestinationId == destinationId);
    }

    public async Task<bool> AddDestination(int clusterId, UpsertDestinationCommand command)
    {
        var destination = new Destination
        {
            ClusterId = clusterId,
            Address = command.Address,
            Health = command.Health,
            Metadata = command.Metadata?.ToKeyValueItems().ToList(),
            CreatedDate = DateTime.UtcNow,
            UpdatedDate = DateTime.UtcNow
        };

        await _dbContext.Destinations.AddAsync(destination);
        await _dbContext.SaveChangesAsync();
        return true; // Return true if the destination was successfully added
    }

    public async Task<bool> UpdateDestination(int clusterId, int destinationId, UpsertDestinationCommand command)
    {
        var destination = await _dbContext.Destinations.FirstOrDefaultAsync(x => x.ClusterId == clusterId && x.DestinationId == destinationId);

        if (destination == null)
            return false;

        destination.Address = command.Address;
        destination.Health = command.Health;
        destination.Metadata = command.Metadata?.ToKeyValueItems().ToList();
        destination.UpdatedDate = DateTime.UtcNow;

        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteDestination(int clusterId, int destinationId)
    {
        var destination = await _dbContext.Destinations.FirstOrDefaultAsync(d => d.ClusterId == clusterId && d.DestinationId == destinationId);

        if (destination == null)
            return false; 

        _dbContext.Destinations.Remove(destination);
        await _dbContext.SaveChangesAsync();

        return true; 
    }
}

