using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Rides.Command;
using Application.Services;
using AutoMapper;
using Core.Domain.Coupons;
using Core.Domain.Rides;
using Core.Factories;
using Core.Repositories;
using MediatR;

namespace Application.Rides.Handlers
{
    public class OrderRideHandler : IRequestHandler<OrderRideCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;
        private readonly ICouponsRepository _couponsRepository;
        private readonly IRidesRepository _ridesRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRidesFactory _ridesFactory;

        public OrderRideHandler(IMapper mapper, IIdentityService identityService,
            ICouponsRepository couponsRepository, IRidesRepository ridesRepository,
            IUnitOfWork unitOfWork, IRidesFactory ridesFactory)
        {
            _mapper = mapper;
            _identityService = identityService;
            _couponsRepository = couponsRepository;
            _ridesRepository = ridesRepository;
            _unitOfWork = unitOfWork;
            _ridesFactory = ridesFactory;
        }

        public async Task<Guid> Handle(OrderRideCommand request, CancellationToken cancellationToken)
        {
            var userId = await _identityService.GetUserIdAsync();

            var ride = await _ridesFactory.CreateRide(userId, request.Address, request.Latitude, request.Longitude, request.CouponCode);
            
            await _ridesRepository.AddRideAsync(ride);
            await _unitOfWork.SaveAsync();

            return ride.Id;
        }
    }
}