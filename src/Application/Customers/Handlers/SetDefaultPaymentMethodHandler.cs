using System.Threading;
using System.Threading.Tasks;
using Application.Customers.Commands;
using Application.Services;
using Core.Repositories;
using MediatR;

namespace Application.Customers.Handlers
{
    public class SetDefaultPaymentMethodHandler : AsyncRequestHandler<SetDefaultPaymentMethodCommand>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIdentityProvider _identityProvider;

        public SetDefaultPaymentMethodHandler(ICustomersRepository customersRepository, IUnitOfWork unitOfWork,
            IIdentityProvider identityProvider)
        {
            _customersRepository = customersRepository;
            _unitOfWork = unitOfWork;
            _identityProvider = identityProvider;
        }
        
        protected override async Task Handle(SetDefaultPaymentMethodCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customersRepository.GetAsync(_identityProvider.GetUserId());

            customer.SetDefaultPaymentMethod(request.PaymentMethodId);

            await _unitOfWork.SaveAsync();
        }
    }
}