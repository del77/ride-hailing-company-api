using System.Collections.Generic;
using Application.Rides.DTOs;
using MediatR;

namespace Application.Customers.Queries
{
    public class GetUnpaidRidesQuery : IRequest<IEnumerable<RideDto>>
    {
        
    }
}