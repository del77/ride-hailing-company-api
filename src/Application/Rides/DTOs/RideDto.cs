using System;
using Core.Domain;
using Core.Domain.Coupons;
using Core.Domain.Rides;

namespace Application.Rides.DTOs
{
    public class RideDto
    {
        public NodeDto Origin { get; }
        public NodeDto? Destination { get; private set; }

        public MoneyDto? Cost { get; private set; }

        public RideStatus Status { get; private set; }
        public bool IsPaid { get; private set; }

    }
}