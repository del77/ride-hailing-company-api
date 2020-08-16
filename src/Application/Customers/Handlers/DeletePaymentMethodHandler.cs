using System.Threading;
using System.Threading.Tasks;
using Application.Customers.Commands;
using Application.Services;
using Core.Repositories;
using MediatR;

namespace Application.Customers.Handlers
{
    public class DeletePaymentMethodHandler : AsyncRequestHandler<DeletePaymentMethodCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomersRepository _customersRepository;
        private readonly IIdentityProvider _identityProvider;

        public DeletePaymentMethodHandler(IUnitOfWork unitOfWork, ICustomersRepository customersRepository,
            IIdentityProvider identityProvider)
        {
            _unitOfWork = unitOfWork;
            _customersRepository = customersRepository;
            _identityProvider = identityProvider;
        }
        
        protected override async Task Handle(DeletePaymentMethodCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customersRepository.GetAsync(_identityProvider.GetUserIdAsync());

            customer.DeletePaymentMethod(request.PaymentMethodId);

            await _unitOfWork.SaveAsync();
        }
    }
}