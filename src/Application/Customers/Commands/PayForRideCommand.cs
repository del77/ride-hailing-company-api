using System;
using MediatR;

namespace Application.Customers.Commands
{
    public class PayForRideCommand : IRequest<bool>
    {
        public Guid RideId { get; set; }
    }
}