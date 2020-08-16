using System;
using MediatR;

namespace Application.Customers.Commands
{
    public class AddPaymentMethodCommand : IRequest<Guid>
    {
        public string CardId { get; set; }
        public string Last4 { get; set; }
    }
}