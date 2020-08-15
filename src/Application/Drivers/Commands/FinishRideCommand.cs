using System;
using MediatR;

namespace Application.Drivers.Commands
{
    public class FinishRideCommand : IRequest
    {
        public Guid RideId { get; set; }
        public decimal KilometersTraveled { get; set; }
    }
}