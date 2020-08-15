using System.Threading;
using System.Threading.Tasks;
using Application.Drivers.Commands;
using Application.Services;
using Core.Repositories;
using Core.Services;
using MediatR;

namespace Application.Drivers.Handlers
{
    public class FinishRideHandler : AsyncRequestHandler<FinishRideCommand>
    {
        private readonly IRidesRepository _ridesRepository;
        private readonly IRidesService _ridesService;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public FinishRideHandler(IUnitOfWork unitOfWork, IRidesRepository ridesRepository, IRidesService ridesService,
            IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _ridesRepository = ridesRepository;
            _ridesService = ridesService;
            _mediator = mediator;
        }

        protected override async Task Handle(FinishRideCommand request, CancellationToken cancellationToken)
        {
            var ride = await _ridesRepository.GetByIdAsync(request.RideId);

            _ridesService.FinishRide(ride, request.KilometersTraveled);

            await _mediator.Publish(new RideFinishedNotification(ride.Id));
        }
    }
}