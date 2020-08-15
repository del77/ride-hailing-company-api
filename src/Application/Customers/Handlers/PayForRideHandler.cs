using System.Threading;
using System.Threading.Tasks;
using Application.Customers.Commands;
using Core.Repositories;
using Core.Services;
using MediatR;

namespace Application.Customers.Handlers
{
    public class PayForRideHandler : IRequestHandler<PayForRideCommand, bool>
    {
        private readonly IRidesRepository _ridesRepository;
        private readonly IRidesService _ridesService;

        public PayForRideHandler(IRidesRepository ridesRepository, IRidesService ridesService)
        {
            _ridesRepository = ridesRepository;
            _ridesService = ridesService;
        }
        
        public async Task<bool> Handle(PayForRideCommand request, CancellationToken cancellationToken)
        {
            var ride = await _ridesRepository.GetByIdAsync(request.RideId);

            var isPaymentSuccessful = await _ridesService.FetchMoneyForRideAsync(ride);
            return isPaymentSuccessful;
        }
    }
}