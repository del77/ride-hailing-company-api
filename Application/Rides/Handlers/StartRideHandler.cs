﻿using System.Threading;
using System.Threading.Tasks;
using Application.Rides.Command;
using Application.Services;
using Core.Repositories;
using MediatR;

namespace Application.Rides.Handlers
{
    public class StartRideHandler : AsyncRequestHandler<StartRideCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRidesRepository _ridesRepository;

        public StartRideHandler(IUnitOfWork unitOfWork, IRidesRepository ridesRepository)
        {
            _unitOfWork = unitOfWork;
            _ridesRepository = ridesRepository;
        }
        
        protected override async Task Handle(StartRideCommand request, CancellationToken cancellationToken)
        {
            var ride = await _ridesRepository.GetByIdAsync(request.RideId);
            
            ride.StartRide(request.Address, request.DestinationLatitude, request.DestinationLongitude);
            
            ride.Version = request.Version;
            await _unitOfWork.SaveAsync();
        }
    }
}