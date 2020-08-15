using System;
using MediatR;

namespace Application.Rides.Command
{
    public class StartRideCommand : IRequest
    {
        public Guid RideId { get; set; }
        public string Address { get; set; }
        public decimal DestinationLatitude { get; set; }
        public decimal DestinationLongitude { get; set; }
    }
}