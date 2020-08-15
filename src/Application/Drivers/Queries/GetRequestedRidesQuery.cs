using System.Collections.Generic;
using Application.Rides.DTOs;
using MediatR;

namespace Application.Drivers.Queries
{
    public class GetRequestedRidesQuery : IRequest<IEnumerable<AvailableRideDto>>
    {
    }
}