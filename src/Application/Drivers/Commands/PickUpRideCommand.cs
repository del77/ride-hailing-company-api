using System;
using MediatR;

namespace Application.Drivers.Commands
{
    public class PickUpRideCommand : IRequest
    {
        public Guid RideId { get; set; }
        public byte[] Version { get; set; }
    }
}