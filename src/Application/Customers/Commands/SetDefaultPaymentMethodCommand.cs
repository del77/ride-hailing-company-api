using System;
using MediatR;

namespace Application.Customers.Commands
{
    public class SetDefaultPaymentMethodCommand : IRequest
    {
        public Guid PaymentMethodId { get; set; }
        public int Test { get; set; }
    }
}