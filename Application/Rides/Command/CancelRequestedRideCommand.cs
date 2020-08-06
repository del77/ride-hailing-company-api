using System;
using MediatR;

namespace Application.Rides.Command
{
    public class CancelRequestedRideCommand : IRequest
    {
        public Guid RideId { get; set; }
    }
}