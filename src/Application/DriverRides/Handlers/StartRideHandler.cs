using System.Threading;
using System.Threading.Tasks;
using Application.DriverRides.Commands;
using Application.Services;
using Core.Repositories;
using MediatR;

namespace Application.DriverRides.Handlers
{
    public class StartRideHandler : AsyncRequestHandler<StartRideCommand>
    {
        private readonly IRidesRepository _ridesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StartRideHandler(IUnitOfWork unitOfWork, IRidesRepository ridesRepository)
        {
            _unitOfWork = unitOfWork;
            _ridesRepository = ridesRepository;
        }

        protected override async Task Handle(StartRideCommand request, CancellationToken cancellationToken)
        {
            var ride = await _ridesRepository.GetByIdAsync(request.RideId);

            ride.StartRide(request.Address, request.DestinationLatitude, request.DestinationLongitude);

            await _unitOfWork.SaveAsync();
        }
    }
}