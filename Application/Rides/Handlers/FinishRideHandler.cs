using System.Threading;
using System.Threading.Tasks;
using Application.Rides.Command;
using Application.Services;
using Core.Repositories;
using Core.Services;
using MediatR;

namespace Application.Rides.Handlers
{
    public class FinishRideHandler : AsyncRequestHandler<FinishRideCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRidesRepository _ridesRepository;
        private readonly IRidesService _ridesService;

        public FinishRideHandler(IUnitOfWork unitOfWork, IRidesRepository ridesRepository, IRidesService ridesService)
        {
            _unitOfWork = unitOfWork;
            _ridesRepository = ridesRepository;
            _ridesService = ridesService;
        }
        
        protected override async Task Handle(FinishRideCommand request, CancellationToken cancellationToken)
        {
            var ride = await _ridesRepository.GetByIdAsync(request.RideId);
            
            _ridesService.FinishRide(ride, request.KilometersTraveled);

            await _unitOfWork.SaveAsync();
        }
    }
}