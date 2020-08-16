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
        private readonly IIdentityService _identityService;
        private readonly IRidesRepository _ridesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PickUpRideHandler(IIdentityService identityService, IRidesRepository ridesRepository,
            IDriversRepository driversRepository, IUnitOfWork unitOfWork, IIdentityProvider identityProvider)
        {
            _identityService = identityService;
            _ridesRepository = ridesRepository;
            _driversRepository = driversRepository;
            _unitOfWork = unitOfWork;
            _identityProvider = identityProvider;
        }

        protected override async Task Handle(PickUpRideCommand request, CancellationToken cancellationToken)
        {
            var userId = _identityProvider.GetUserIdAsync();

            var driver = await _driversRepository.GetByIdAsync(userId);
            var ride = await _ridesRepository.GetByIdAsync(request.RideId);

            ride.AssignDriver(driver);

            ride.Version = request.Version;
            await _unitOfWork.SaveAsync();
        }
    }
}