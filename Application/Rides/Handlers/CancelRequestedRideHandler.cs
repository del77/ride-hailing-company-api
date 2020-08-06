using System.Threading;
using System.Threading.Tasks;
using Application.Rides.Command;
using Application.Services;
using Core.Repositories;
using MediatR;

namespace Application.Rides.Handlers
{
    public class CancelRequestedRideHandler : AsyncRequestHandler<CancelRequestedRideCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRidesRepository _ridesRepository;

        public CancelRequestedRideHandler(IUnitOfWork unitOfWork, IRidesRepository ridesRepository)
        {
            _unitOfWork = unitOfWork;
            _ridesRepository = ridesRepository;
        }
        
        protected override async Task Handle(CancelRequestedRideCommand request, CancellationToken cancellationToken)
        {
            var ride = await _ridesRepository.GetByIdAsync(request.RideId);
            ride.Cancel();

            await _unitOfWork.SaveAsync();
        }
    }
}