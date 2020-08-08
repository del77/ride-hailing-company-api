using System;
using Application.Rides.DTOs;
using MediatR;

namespace Application.Rides.Queries
{
    public class GetRideQuery : IRequest<RideDto>
    {
        public Guid RideId { get; set; }
    }
}