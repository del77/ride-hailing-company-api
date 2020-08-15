using System.Collections.Generic;
using Application.Customers.DTOs;
using MediatR;

namespace Application.Customers.Queries
{
    public class GetPaymentMethodsQuery : IRequest<IEnumerable<PaymentMethodDto>>
    {
        
    }
}