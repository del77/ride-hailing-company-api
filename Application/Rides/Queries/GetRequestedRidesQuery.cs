using System.Collections.Generic;
using Application.Rides.DTOs;
using MediatR;

namespace Application.Rides.Queries
{
    public class GetRequestedRidesQuery : IRequest<IEnumerable<AvailableRideDto>>
    {
        
    }
}