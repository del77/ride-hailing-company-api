using System.Threading;
using System.Threading.Tasks;
using Application.Rides.DTOs;
using Application.Rides.Queries;
using AutoMapper;
using Core.Repositories;
using MediatR;

namespace Application.Rides.Handlers
{
    public class GetRideHandler : IRequestHandler<GetRideQuery, RideDto>
    {
        private readonly IRidesRepository _ridesRepository;
        private readonly IMapper _mapper;

        public GetRideHandler(IRidesRepository ridesRepository, IMapper mapper)
        {
            _ridesRepository = ridesRepository;
            _mapper = mapper;
        }
        
        public async Task<RideDto> Handle(GetRideQuery request, CancellationToken cancellationToken)
        {
            var ride = await _ridesRepository.GetByIdAsync(request.RideId);

            return _mapper.Map<RideDto>(ride);
        }
    }
}