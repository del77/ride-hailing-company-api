using System;
using MediatR;

namespace Application.Customers.Commands
{
    public class DeletePaymentMethodCommand : IRequest
    {
        public Guid PaymentMethodId { get; set; }
    }
}