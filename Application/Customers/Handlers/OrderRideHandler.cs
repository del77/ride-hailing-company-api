using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Rides.Command;
using Application.Services;
using Core.Factories;
using Core.Repositories;
using MediatR;

namespace Application.Rides.Handlers
{
    public class OrderRideHandler : IRequestHandler<OrderRideCommand, Guid>
    {
        private readonly IIdentityProvider _identityProvider;
        private readonly IRidesFactory _ridesFactory;
        private readonly IRidesRepository _ridesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderRideHandler(IRidesRepository ridesRepository,
            IUnitOfWork unitOfWork, IRidesFactory ridesFactory, IIdentityProvider identityProvider)
        {
            _ridesRepository = ridesRepository;
            _unitOfWork = unitOfWork;
            _ridesFactory = ridesFactory;
            _identityProvider = identityProvider;
        }

        public async Task<Guid> Handle(OrderRideCommand request, CancellationToken cancellationToken)
        {
            var userId = _identityProvider.GetUserIdAsync();

            var ride = await _ridesFactory.CreateRide(userId, request.Address, request.Latitude, request.Longitude,
                request.CouponCode);

            await _ridesRepository.AddRideAsync(ride);
            await _unitOfWork.SaveAsync();

            return ride.Id;
        }
    }
}