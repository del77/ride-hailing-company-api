using System.Data;
using Application.Rides.Command;
using FluentValidation;

namespace Application.Rides.Validation
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