﻿using System;
using Application.Rides.DTOs;
using MediatR;

namespace Application.Rides.Queries
{
    public class GetCurrentRideQuery : IRequest<RideDto>
    {
        public Guid RideId { get; set; }
    }
}