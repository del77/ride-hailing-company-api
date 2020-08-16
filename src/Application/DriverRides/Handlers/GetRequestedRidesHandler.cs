using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DriverRides.Queries;
using Application.Rides.DTOs;
using AutoMapper;
using Core.Repositories;
using MediatR;

namespace Application.DriverRides.Handlers
{
    public class GetRequestedRidesHandler : IRequestHandler<GetRequestedRidesQuery, IEnumerable<AvailableRideDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRidesRepository _ridesRepository;

        public GetRequestedRidesHandler(IRidesRepository ridesRepository, IMapper mapper)
        {
            _ridesRepository = ridesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AvailableRideDto>> Handle(GetRequestedRidesQuery request,
            CancellationToken cancellationToken)
        {
            var rides = await _ridesRepository.GetAvailableRidesAsync();

            return _mapper.Map<IEnumerable<AvailableRideDto>>(rides);
        }
    }
}