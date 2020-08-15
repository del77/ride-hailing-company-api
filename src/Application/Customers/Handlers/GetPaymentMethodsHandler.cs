using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Customers.DTOs;
using Application.Customers.Queries;
using Application.Services;
using AutoMapper;
using Core.Repositories;
using MediatR;

namespace Application.Customers.Handlers
{
    public class GetPaymentMethodsHandler : IRequestHandler<GetPaymentMethodsQuery, IEnumerable<PaymentMethodDto>>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IIdentityProvider _identityProvider;
        private readonly IMapper _mapper;

        public GetPaymentMethodsHandler(ICustomersRepository customersRepository, IIdentityProvider identityProvider,
            IMapper mapper)
        {
            _customersRepository = customersRepository;
            _identityProvider = identityProvider;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<PaymentMethodDto>> Handle(GetPaymentMethodsQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customersRepository.GetAsync(_identityProvider.GetUserIdAsync());

            return _mapper.Map<IEnumerable<PaymentMethodDto>>(customer.PaymentMethods);
        }
    }
}