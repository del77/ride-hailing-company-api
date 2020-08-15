using System.Collections.Generic;
using Application.Rides.DTOs;
using MediatR;

namespace Application.Rides.Queries
{
    public class GetRidesHistoryQuery : IRequest<IEnumerable<RideDto>>
    {
    }
}