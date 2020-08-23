using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Customers.Commands;
using Application.Services;
using AutoMapper;
using Core.Domain.Customers;
using Core.Repositories;
using MediatR;

namespace Application.Customers.Handlers
{
    public class AddPaymentMethodHandler : IRequestHandler<AddPaymentMethodCommand, Guid>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IIdentityProvider _identityProvider;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AddPaymentMethodHandler(ICustomersRepository customersRepository, IIdentityProvider identityProvider,
            IMapper mapper, IUnitOfWork unitOfWork)
        {
            _customersRepository = customersRepository;
            _identityProvider = identityProvider;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(AddPaymentMethodCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customersRepository.GetAsync(_identityProvider.GetUserId());

            var paymentMethod = _mapper.Map<PaymentMethod>(request);
            customer.AddPaymentMethod(paymentMethod);

            await _unitOfWork.SaveAsync();
            return paymentMethod.Id;
        }
    }
}