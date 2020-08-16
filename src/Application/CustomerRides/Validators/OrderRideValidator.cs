using Application.CustomerRides.Commands;
using FluentValidation;

namespace Application.CustomerRides.Validators
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