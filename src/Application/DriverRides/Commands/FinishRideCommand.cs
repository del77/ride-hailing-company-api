using System;
using MediatR;

namespace Application.DriverRides.Commands
{
    public class FinishRideCommand : IRequest
    {
        public Guid RideId { get; set; }
        public decimal KilometersTraveled { get; set; }
    }
}