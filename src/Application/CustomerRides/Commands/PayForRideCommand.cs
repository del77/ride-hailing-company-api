using System;
using MediatR;

namespace Application.CustomerRides.Commands
{
    public class PayForRideCommand : IRequest<bool>
    {
        public Guid RideId { get; set; }
    }
}