using System;
using Core.Domain.Rides;

namespace Core.Exceptions
{
    public class InvalidRideStatusException : DomainException
    {
        public InvalidRideStatusException(RideStatus status, Guid rideId)
            : base($"Invalid ride status: '{status}' for ride with id: {rideId}")
        {
        }

        public override string Code { get; } = "invalid_ride_status";
    }
}