using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Services;
using Core.Repositories;
using Core.Services;
using MediatR;

namespace Application.CustomerRides.Handlers
{    
    public class RidePaymentHandler : INotificationHandler<RideFinishedNotification>
    {
        private readonly IRidesService _ridesService;
        private readonly IRidesRepository _ridesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RidePaymentHandler(IRidesService ridesService, IRidesRepository ridesRepository, IUnitOfWork unitOfWork)
        {
            _ridesService = ridesService;
            _ridesRepository = ridesRepository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task Handle(RideFinishedNotification notification, CancellationToken cancellationToken)
        {
            var ride = await _ridesRepository.GetByIdAsync(notification.RideId);
            
            await _ridesService.FetchMoneyForRideAsync(ride);

            await _unitOfWork.SaveAsync();
        }
    }
}