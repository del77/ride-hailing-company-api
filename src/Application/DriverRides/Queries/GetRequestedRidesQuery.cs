using System.Collections.Generic;
using Application.Rides.DTOs;
using MediatR;

namespace Application.DriverRides.Queries
{
    public class GetRequestedRidesQuery : IRequest<IEnumerable<AvailableRideDto>>
    {
    }
}