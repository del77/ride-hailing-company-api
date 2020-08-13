using System;
using MediatR;

namespace Application.Rides.Command
{
    public class FinishRideCommand : IRequest
    {
        public Guid RideId { get; set; }
        public decimal KilometersTraveled { get; set; }
    }
}