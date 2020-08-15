using System.Collections.Generic;
using Application.Rides.DTOs;
using MediatR;

namespace Application.Customers.Queries
{
    public class GetRidesHistoryQuery : IRequest<IEnumerable<RideDto>>
    {
    }
}