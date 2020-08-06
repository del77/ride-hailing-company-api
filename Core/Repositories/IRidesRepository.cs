using System;
using System.Threading.Tasks;
using Core.Domain.Rides;

namespace Core.Repositories
{
    public interface IRidesRepository
    {
        Task AddRideAsync(Ride ride);
        Task<Ride> GetByIdAsync(Guid rideId);
    }
}