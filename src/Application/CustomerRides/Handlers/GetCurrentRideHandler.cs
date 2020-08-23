using System.Threading;
using System.Threading.Tasks;
using Application.CustomerRides.Queries;
using Application.Exceptions;
using Application.Rides.DTOs;
using Application.Services;
using AutoMapper;
using Core.Domain.Rides;
using Core.Repositories;
using MediatR;

namespace Application.CustomerRides.Handlers
{
    public class GetCurrentRideHandler : IRequestHandler<GetCurrentRideQuery, RideDto>
    {
        private readonly IIdentityProvider _identityProvider;
        private readonly IMapper _mapper;
        private readonly IRidesRepository _ridesRepository;

        public GetCurrentRideHandler(IRidesRepository ridesRepository, IMapper mapper,
            IIdentityProvider identityProvider)
        {
            _ridesRepository = ridesRepository;
            _mapper = mapper;
            _identityProvider = identityProvider;
        }

        public async Task<RideDto> Handle(GetCurrentRideQuery request, CancellationToken cancellationToken)
        {
            var ride = await _ridesRepository.GetCurrentCustomerRideAsync(_identityProvider.GetUserId());

            if (ride is null)
                throw new ResourceDoesNotExistException(typeof(Ride));

            return _mapper.Map<RideDto>(ride);
        }
    }
}