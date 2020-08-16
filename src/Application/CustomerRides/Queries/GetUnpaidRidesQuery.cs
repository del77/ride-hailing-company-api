using System.Collections.Generic;
using Application.Rides.DTOs;
using MediatR;

namespace Application.CustomerRides.Queries
{
    public class GetUnpaidRidesQuery : IRequest<IEnumerable<RideDto>>
    {
        
    }
}