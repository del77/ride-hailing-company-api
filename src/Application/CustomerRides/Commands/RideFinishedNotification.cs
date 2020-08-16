using System;
using MediatR;

namespace Application.CustomerRides.Commands
{
    public class RideFinishedNotification : INotification
    {
        public RideFinishedNotification(Guid rideId)
        {
            RideId = rideId;
        }
        
        public Guid RideId { get; set; }
    }
}