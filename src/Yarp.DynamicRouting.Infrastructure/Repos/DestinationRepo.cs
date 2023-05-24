using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using Yarp.DynamicRouting.Core.Commands;
using Yarp.DynamicRouting.Core.Common.Models;
using Yarp.DynamicRouting.Core.Entities;
using Yarp.DynamicRouting.Core.Interfaces.Db;
using Yarp.DynamicRouting.Core.Interfaces.Repos;

namespace Yarp.DynamicRouting.Infrastructure.Repos;
public class DestinationRepo : IDestinationRepo
{
    private readonly IPgContext _pgContext;

    public DestinationRepo(IPgContext pgContext)
    {
        _pgContext = pgContext;
    }

    public async Task<IEnumerable<Destination>> GetAllDestinations(int clusterId)
    {
        return await _pgContext.Destinations.Where(d => d.ClusterId == clusterId).ToListAsync();
    }

    public async Task<Destination?> GetDestination(int clusterId, int destinationId)
    {
        return await _pgContext.Destinations.FirstOrDefaultAsync(d => d.ClusterId == clusterId && d.DestinationId == destinationId);
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

        await _pgContext.Destinations.AddAsync(destination);
        var rowsAffected = await _pgContext.SaveChangesAsync();
        return rowsAffected > 0;
    }

    public async Task<bool> UpdateDestination(int clusterId, int destinationId, UpsertDestinationCommand command)
    {
        var destination = await _pgContext.Destinations.FirstOrDefaultAsync(x => x.ClusterId == clusterId && x.DestinationId == destinationId);

        if (destination == null)
            return false;

        destination.Address = command.Address;
        destination.Health = command.Health;
        destination.Metadata = command.Metadata?.ToKeyValueItems().ToList();
        destination.UpdatedDate = DateTime.UtcNow;

        var rowsAffected = await _pgContext.SaveChangesAsync();
        return rowsAffected > 0;
    }

    public async Task<bool> DeleteDestination(int clusterId, int destinationId)
    {
        var destination = await _pgContext.Destinations.FirstOrDefaultAsync(d => d.ClusterId == clusterId && d.DestinationId == destinationId);

        if (destination == null)
            return false;

        _pgContext.Destinations.Remove(destination);
        var rowsAffected = await _pgContext.SaveChangesAsync();
        return rowsAffected > 0;
    }

    public async Task<bool> DeleteDestinations(int clusterId)
    {
        var destinations = await _pgContext.Destinations.Where(r => r.ClusterId == clusterId).ToListAsync();

        _pgContext.Destinations.RemoveRange(destinations);
        var rowsAffected = await _pgContext.SaveChangesAsync();
        return rowsAffected > 0;    
    }
}

