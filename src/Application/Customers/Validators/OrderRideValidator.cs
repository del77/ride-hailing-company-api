using Application.Customers.Commands;
using FluentValidation;

namespace Application.Customers.Validators
{
    public class OrderRideValidator : AbstractValidator<OrderRideCommand>
    {
        public OrderRideValidator()
        {
            RuleFor(r => r.Address).NotEmpty();
            RuleFor(r => r.Latitude).NotEmpty();
            RuleFor(r => r.Longitude).NotEmpty();
        }
    }
}