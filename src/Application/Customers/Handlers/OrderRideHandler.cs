using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Customers.Commands;
using Application.Services;
using Core.Factories;
using Core.Repositories;
using MediatR;

namespace Application.Customers.Handlers
{
    public class OrderRideHandler : IRequestHandler<OrderRideCommand, Guid>
    {
        private readonly IIdentityProvider _identityProvider;
        private readonly IRideFactory _rideFactory;
        private readonly IRidesRepository _ridesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderRideHandler(IRidesRepository ridesRepository,
            IUnitOfWork unitOfWork, IIdentityProvider identityProvider, IRideFactory rideFactory)
        {
            _ridesRepository = ridesRepository;
            _unitOfWork = unitOfWork;
            _identityProvider = identityProvider;
            _rideFactory = rideFactory;
        }

        public async Task<Guid> Handle(OrderRideCommand request, CancellationToken cancellationToken)
        {
            var userId = _identityProvider.GetUserIdAsync();
            var ride = await _rideFactory.CreateRideAsync(userId, request.Address, request.Latitude, request.Longitude,
                request.CouponCode);

            await _ridesRepository.AddRideAsync(ride);
            await _unitOfWork.SaveAsync();

            return ride.Id;
        }
    }
}