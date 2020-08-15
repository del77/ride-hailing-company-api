using System;
using MediatR;

namespace Application.Rides.Command
{
    public class PickUpRideCommand : IRequest
    {
        public Guid RideId { get; set; }
        public byte[] Version { get; set; }
    }
}