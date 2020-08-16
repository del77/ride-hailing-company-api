using System;
using MediatR;

namespace Application.DriverRides.Commands
{
    public class PickUpRideCommand : IRequest
    {
        public Guid RideId { get; set; }
        public byte[] Version { get; set; }
    }
}