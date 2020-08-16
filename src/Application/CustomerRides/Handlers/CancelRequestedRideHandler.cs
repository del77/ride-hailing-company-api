using System.Threading;
using System.Threading.Tasks;
using Application.CustomerRides.Commands;
using Application.Customers.Commands;
using Application.Services;
using Core.Repositories;
using MediatR;

namespace Application.CustomerRides.Handlers
{
    public class CancelRequestedRideHandler : AsyncRequestHandler<CancelRequestedRideCommand>
    {
        private readonly IRidesRepository _ridesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CancelRequestedRideHandler(IUnitOfWork unitOfWork, IRidesRepository ridesRepository)
        {
            _unitOfWork = unitOfWork;
            _ridesRepository = ridesRepository;
        }

        protected override async Task Handle(CancelRequestedRideCommand request, CancellationToken cancellationToken)
        {
            var ride = await _ridesRepository.GetByIdAsync(request.RideId);
            ride.Cancel();

            ride.Version = request.Version;
            await _unitOfWork.SaveAsync();
        }
    }
}