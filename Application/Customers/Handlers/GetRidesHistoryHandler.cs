using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Rides.DTOs;
using Application.Rides.Queries;
using Core.Repositories;
using MediatR;

namespace Application.Rides.Handlers
{
    public class GetRidesHistoryHandler : IRequestHandler<GetRidesHistoryQuery, IEnumerable<RideDto>>
    {
        private readonly IRidesRepository _ridesRepository;

        public GetRidesHistoryHandler(IRidesRepository ridesRepository)
        {
            _ridesRepository = ridesRepository;
        }

        public async Task<IEnumerable<RideDto>> Handle(GetRidesHistoryQuery request,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}