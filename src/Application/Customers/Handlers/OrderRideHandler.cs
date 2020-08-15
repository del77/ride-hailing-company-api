using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Customers.Commands;
using Application.Services;
using Core.Domain.Rides;
using Core.Repositories;
using MediatR;

namespace Application.Customers.Handlers
{
    public class OrderRideHandler : IRequestHandler<OrderRideCommand, Guid>
    {
        private readonly IIdentityProvider _identityProvider;
        private readonly IRidesRepository _ridesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderRideHandler(IRidesRepository ridesRepository,
            IUnitOfWork unitOfWork, IIdentityProvider identityProvider)
        {
            _ridesRepository = ridesRepository;
            _unitOfWork = unitOfWork;
            _identityProvider = identityProvider;
        }

        public async Task<Guid> Handle(OrderRideCommand request, CancellationToken cancellationToken)
        {
            var userId = _identityProvider.GetUserIdAsync();
            var ride = new Ride(userId, request.Address, request.Latitude, request.Longitude);

            await _ridesRepository.AddRideAsync(ride);
            await _unitOfWork.SaveAsync();

            return ride.Id;
        }
    }
}