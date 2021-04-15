using System.Threading;
using System.Threading.Tasks;
using Application.Customers.Commands;
using Application.Services;
using Core.Repositories;
using MediatR;

namespace Application.Customers.Handlers
{
    public class AddOpinionForDriverHandler : AsyncRequestHandler<AddOpinionForDriverCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDriversRepository _driversRepository;
        private readonly IIdentityProvider _identityProvider;

        public AddOpinionForDriverHandler(IUnitOfWork unitOfWork, IDriversRepository driversRepository,
            IIdentityProvider identityProvider)
        {
            _unitOfWork = unitOfWork;
            _driversRepository = driversRepository;
            _identityProvider = identityProvider;
        }
        
        protected override async Task Handle(AddOpinionForDriverCommand request, CancellationToken cancellationToken)
        {
            var driver = await _driversRepository.GetByIdAsync(request.DriverId);

            // driver.AddOpinion(request.Value, request.Description, _identityProvider.GetUserId());
            // await _unitOfWork.SaveAsync();
        }
    }
}