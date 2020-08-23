using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.DriverRides.Commands
{
    public class PickUpRideCommand : IRequest
    {
        public Guid RideId { get; set; }
        [FromQuery]
        public byte[] Version { get; set; }
    }
}