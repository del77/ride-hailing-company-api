using System;
using MediatR;

namespace Application.Rides.Command
{
    public class OrderRideCommand : IRequest<Guid>
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Address { get; set; }
        public string? CouponCode { get; set; }
    }
}