using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Rides.DTOs;
using Application.Rides.Queries;
using AutoMapper;
using Core.Repositories;
using MediatR;

namespace Application.Rides.Handlers
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