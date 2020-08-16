using System;
using MediatR;

namespace Application.CustomerRides.Commands
{
    public class CancelRequestedRideCommand : IRequest
    {
        public Guid RideId { get; set; }
        public byte[] Version { get; set; }
    }
}