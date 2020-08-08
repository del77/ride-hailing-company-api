﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Rides;
using Core.Specifications;

namespace Core.Repositories
{
    public interface IRidesRepository
    {
        Task AddRideAsync(Ride ride);
        Task<Ride> GetByIdAsync(Guid rideId);
        Task<IEnumerable<Ride>> GetAvailableRidesAsync();
    }
}