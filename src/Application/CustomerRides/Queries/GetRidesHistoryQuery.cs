using System.Collections.Generic;
using Application.Rides.DTOs;
using MediatR;

namespace Application.CustomerRides.Queries
{
    public class GetRidesHistoryQuery : IRequest<IEnumerable<RideDto>>
    {
    }
}