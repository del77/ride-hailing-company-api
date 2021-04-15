using System.Threading;
using System.Threading.Tasks;
using Application.DriverRides.Commands;
using Application.Services;
using Core.Repositories;
using MediatR;

namespace Application.DriverRides.Handlers
{
    public class PickUpRideHandler : AsyncRequestHandler<PickUpRideCommand>
    {
        private readonly IDriversRepository _driversRepository;
        private readonly IIdentityProvider _identityProvider;
        private readonly IRidesRepository _ridesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PickUpRideHandler(IRidesRepository ridesRepository,
            IDriversRepository driversRepository, IUnitOfWork unitOfWork, IIdentityProvider identityProvider)
        {
            _ridesRepository = ridesRepository;
            _driversRepository = driversRepository;
            _unitOfWork = unitOfWork;
            _identityProvider = identityProvider;
        }

        protected override async Task Handle(PickUpRideCommand request, CancellationToken cancellationToken)
        {
            var userId = _identityProvider.GetUserId();

            var driver = await _driversRepository.GetByIdAsync(userId);
            var ride = await _ridesRepository.GetByIdAsync(request.RideId);

            ride.AssignDriver(driver);

            ride.Version = request.Version;
            await _unitOfWork.SaveAsync();
        }
    }
}