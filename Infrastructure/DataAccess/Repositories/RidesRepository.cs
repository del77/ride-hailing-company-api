using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Rides;
using Core.Repositories;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repositories
{
    public class RidesRepository : IRidesRepository
    {
        private readonly RideHailingContext _hailingContext;

        public RidesRepository(RideHailingContext hailingContext)
        {
            _hailingContext = hailingContext;
        }
        
        public async Task AddRideAsync(Ride ride)
        {
            await _hailingContext.Rides.AddAsync(ride);
        }

        public async Task<Ride> GetByIdAsync(Guid rideId)
        {
            return await _hailingContext.Rides.FindAsync(rideId);
        }

        public async Task<IEnumerable<Ride>> GetAvailableRidesAsync()
        {
            return await _hailingContext.Rides
                .Where(r => r.Status == RideStatus.Requested)
                .ToListAsync();
        }
    }
}