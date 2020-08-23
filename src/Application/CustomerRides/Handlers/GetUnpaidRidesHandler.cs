using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.CustomerRides.Queries;
using Application.Rides.DTOs;
using Application.Services;
using AutoMapper;
using Core.Repositories;
using MediatR;

namespace Application.CustomerRides.Handlers
{
    public class GetUnpaidRidesHandler : IRequestHandler<GetUnpaidRidesQuery, IEnumerable<RideDto>>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IIdentityProvider _identityProvider;
        private readonly IMapper _mapper;

        public GetUnpaidRidesHandler(ICustomersRepository customersRepository, IIdentityProvider identityProvider, IMapper mapper)
        {
            _customersRepository = customersRepository;
            _identityProvider = identityProvider;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<RideDto>> Handle(GetUnpaidRidesQuery request, CancellationToken cancellationToken)
        {
            var unpaidRides = await _customersRepository.GetUnpaidRidesAsync(_identityProvider.GetUserId());

            return _mapper.Map<IEnumerable<RideDto>>(unpaidRides);
        }
    }
}