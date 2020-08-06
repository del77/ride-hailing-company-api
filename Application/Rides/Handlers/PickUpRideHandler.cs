using System.Threading;
using System.Threading.Tasks;
using Application.Rides.Command;
using Application.Services;
using Core.Repositories;
using MediatR;

namespace Application.Rides.Handlers
{
    public class PickUpRideHandler : AsyncRequestHandler<PickUpRideCommand>
    {
        private readonly IIdentityService _identityService;
        private readonly IRidesRepository _ridesRepository;
        private readonly IDriversRepository _driversRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PickUpRideHandler(IIdentityService identityService, IRidesRepository ridesRepository,
            IDriversRepository driversRepository, IUnitOfWork unitOfWork)
        {
            _identityService = identityService;
            _ridesRepository = ridesRepository;
            _driversRepository = driversRepository;
            _unitOfWork = unitOfWork;
        }

        protected override async Task Handle(PickUpRideCommand request, CancellationToken cancellationToken)
        {
            var userId = await _identityService.GetUserIdAsync();

            var driver = await _driversRepository.GetByIdAsync(userId);
            var ride = await _ridesRepository.GetByIdAsync(request.RideId);
            
            ride.AssignDriver(driver);
            await _unitOfWork.SaveAsync();
        }
    }
}